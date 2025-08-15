using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Data;
using WebAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SetupController : ControllerBase
{
    private readonly DataContext _context;
    public SetupController(DataContext context)
    {
        _context = context;
    }

    // GET: api/<SetupController>
    [HttpGet]
    public async Task<List<DcaSetup>> Get()
    {
        return await GetDcaSetups();
    }

    // GET api/<SetupController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<SetupController>
    [HttpPost]
    public async Task<ActionResult<List<DcaSetup>>> Post([FromBody] DcaSetup setup)
    {
        if (setup is null)
            return StatusCode(401, "Invalid input");

        // We need to first add all the token shares to the DB
        foreach (TokenShare share in setup.Shares)
        {

            var existingToken = await _context.Tokens
                                            .FirstOrDefaultAsync(t => t.CmcId == share.Token.CmcId);

            if (existingToken is null)
            {
                _context.Tokens.Add(share.Token);
                await _context.SaveChangesAsync();
            }
            else
                share.Token = existingToken;

                // Then we need to initiate a new balance for each token that don't have one (upon the user)
                if (!(await _context.Balances.AnyAsync(b => b.Token.Symbol == share.Token.Symbol)))
                {
                    _context.Balances.Add(new Balance
                    {
                        Token = share.Token,
                        UserDataId = setup.UserDataId,
                        AmountUSD = 0
                    });

                    await _context.SaveChangesAsync();
                }

            // Now we can add the shares
            _context.TokenShares.Add(share);
        }

        // Set by default day of the month as the day of the creation of the setup
        if (setup.DayOfMonth is null)
            setup.DayOfMonth = setup.CreatedAt.Day;

        _context.Setups.Add(setup);
        await _context.SaveChangesAsync();
        return StatusCode(201, await GetDcaSetups());

    }

    // PUT api/<SetupController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<SetupController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
    /// <summary>
    /// Get all the Dollar Cost avg setups
    /// </summary>
    /// <returns>the curent DCA setups as a list</returns>
    private async Task<List<DcaSetup>> GetDcaSetups ()
    {
        return await  _context.Setups
                        .Include(u => u.UserData)
                        .Include(u => u.Shares)
                        .ThenInclude(u => u.Token)
                        .ToListAsync();
    }
}
