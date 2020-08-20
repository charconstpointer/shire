using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shire.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShireController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get() => Ok("🎀");
    }
}