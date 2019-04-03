using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace helloworld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiplierController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public MultiplierController(ILogger<MultiplierController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        
        
        private int getValueMultiplier()
        {
            int valueMultiplier = _configuration.GetValue<int>("ValueMultiplier");
            _logger.LogWarning("Value Multiplier Used: {}", valueMultiplier);
            return valueMultiplier;
        }
        
         
        // GET api/multiplier
        [HttpGet]
        public ActionResult<int> Get()
        {
            return getValueMultiplier();
        }

        // GET api/multiplier/5
        [HttpGet("{value}")]
        public ActionResult<int> Get(int value)
        {
            return getValueMultiplier() * value;
        }
    }
}
