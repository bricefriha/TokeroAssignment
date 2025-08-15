using CoinMarketCap;
using CoinMarketCap.Models.Cryptocurrency;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Data;
using WebAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {

        private CoinMarketCapClient _client;
        private readonly DataContext _context;
        public TokensController(CoinMarketCapClient client,
                                    DataContext context)
        {
            _client = client;
                _context = context;

        }

        // GET: api/<TokensController>
        [HttpGet]
        public async Task<IEnumerable<WebAPI.Data.Token>> Get()
        {
            return (await _client.GetLatestListingsAsync(new ListingLatestParameters(), CancellationToken.None))?.Data.Select(l => new WebAPI.Data.Token
            {
                Name = l.Name,
                CmcId =  unchecked((int)l.Id),
                Symbol = l.Symbol,
                Changes = l.Quote["USD"].PercentChange24H,
                PriceUsd = l.Quote["USD"].Price,


            })?.Take(10);
        }

    // GET: api/<TokensController>
    [HttpGet("investments")]
    public async Task<ActionResult<IEnumerable<DcaInvestment>>> GetInvestments()
    {
        var orders = await _context.Orders
                        .GroupBy(od => od.Token)
                        .ToDictionaryAsync(g => g.Key, g => g.ToList());
        var updatedTokenVals = (await _client.GetLatestListingsAsync(new ListingLatestParameters(), CancellationToken.None))?.Data.Select(l => new WebAPI.Data.Token
        {
            Name = l.Name,
            CmcId = unchecked((int)l.Id),
            Symbol = l.Symbol,
            Changes = l.Quote["USD"].PercentChange24H,
            PriceUsd = l.Quote["USD"].Price,
        });

        if (updatedTokenVals is null)
            return StatusCode(500, "couldn't get the market data");

        List<DcaInvestment> investments = [];
        // go through each tokens
        foreach (var tokenOrdered in orders)
        {
            Token? token = updatedTokenVals.SingleOrDefault(utv => utv.CmcId == tokenOrdered.Key.CmcId);

            if (token is null)
                continue;

            double amountUSD = 0;
            double amountToken = 0;
            foreach (var order in tokenOrdered.Value)
            {
                amountUSD += order.Price;
                amountToken += order.AmountToken;
            }
            double currValue = (token.PriceUsd ?? 0) * amountToken;
            investments.Add(new()
            {
                Token = token,
                AmountToken = amountToken,
                AmountUSD = amountUSD,
                CurrentValue = currValue,
                PourcentageChange = ((currValue - amountUSD)/amountUSD)*100
            });
        }
        return StatusCode(200, investments);
    }

    // GET api/<TokensController>/5
    [HttpGet("/symbol/{symbol}")]
    public async Task<ActionResult<WebAPI.Data.Token?>> Get(string symbol)
    {
        if (string.IsNullOrEmpty(symbol))
            return BadRequest();

        var quote =(await _client.GetLatestQuoteAsync(new LatestQuoteParameters { Id = 2010 }, CancellationToken.None))?.Data;
        
        if (quote is null)
            return StatusCode(404, null);

        // We translate the quote to our Token object to return it
        return new Data.Token()
        {
            Name = quote.Name,
            //CmcId = unchecked((int)quote.Id),
            Symbol = quote.Symbol,
            Changes = quote.Quote["USD"].PercentChange24H,
            PriceUsd = quote.Quote["USD"].Price,


        };
    }
    // GET api/<TokensController>/cmcID
    [HttpGet("balance/{cmcId}")]
    public async Task<ActionResult<Balance?>> GetBalanceByCmcId(int cmcId)
    {
        return Ok(_context.Balances.Include(o => o.Token)
                                .FirstOrDefault(bl => bl.Token.CmcId == cmcId));

    }
}
