using CoinMarketCap;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Data;
using WebAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        // GET api/<OrderController>/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Order>>> Get(Guid userId)
        {
            return StatusCode(200, await _context.Orders.Where(order => order.UserDataId == userId)
                            .Include(o => o.Token)
                            .ToListAsync());
        }
    }
}
