using CodeChallengeBootstrap;
using Domain.AccessModifiers;
using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Controllers
{
    [ApiController]
    [Route("api/AccessModifiersInfo")]
    public class AccessModifiersInfoController : Controller
    {
        private readonly IProcessAccessModifiers _process;

        public AccessModifiersInfoController(IBootstrapAccessModifiers bootstrap) => _process = bootstrap.BootstrapAccessModifiersProcess();

        [HttpGet]
        public IActionResult AccessModifiersInfo() => Ok(_process.ReadAccessModifiersInfo());
    }
}