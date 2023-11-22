using ETC.PoliceInquery.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace ETC.PoliceInquery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoliceInquery : ControllerBase
    {
        private readonly ILogger<PoliceInquery> _logger;
        public PoliceInquery(ILogger<PoliceInquery> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "SendTrafficData")]
        public async Task<IActionResult> SendTrafficData(TrafficModelRequestDto trafficModel)
        {
           return Ok(trafficModel);
        }
    }
}