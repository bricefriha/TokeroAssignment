using CoinMarketCap;
using CoinMarketCap.Models.Cryptocurrency;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
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
    }
}
