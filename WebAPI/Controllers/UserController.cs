using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Data;
using WebAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }

    // GET: api/<UserController>
    [HttpGet]
    public async Task<ActionResult<UserData>> Get()
    {
        return Ok((await _context.Data
                .Include(u => u.Balances)
                .ThenInclude(b => b.Token)
                .Include(u => u.Shares)
                .Include(u => u.Orders)
                .ToListAsync())?
                .FirstOrDefault());
    }
}
