using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockListAPI.Helpers;
using StockListAPI.Models;

namespace StockListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly ILogger<StocksController> _logger;

        public StocksController(ILogger<StocksController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new StocksHelper().GetStockList();
        }
    }
}
