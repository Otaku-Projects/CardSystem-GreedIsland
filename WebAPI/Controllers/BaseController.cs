using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    //[AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
    }
}
