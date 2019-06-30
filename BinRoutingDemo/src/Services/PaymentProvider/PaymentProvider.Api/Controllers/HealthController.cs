using Microsoft.AspNetCore.Mvc;

namespace PaymentProvider.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Health")]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Get() => Ok("ok");

    }
}