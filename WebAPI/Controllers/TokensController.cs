using CoinMarketCap;
using CoinMarketCap.Models.Cryptocurrency;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {

        private CoinMarketCapClient _client;
        public TokensController(CoinMarketCapClient client)
        {
            _client = client;

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

    // GET api/<TokensController>/5
    [HttpGet("{symbol}")]
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

    // POST api/<TokensController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<TokensController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<TokensController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
