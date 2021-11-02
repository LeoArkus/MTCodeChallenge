using CodeChallengeBootstrap;
using Commons;
using Domain.OOP;
using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Controllers
{
    [ApiController]
    [Route("api/OOPInfo")]
    public class OOPInfoController : Controller
    {
        private readonly IProcessOOPInfo _process;

        public OOPInfoController(IBootstrapOOP bootstrap) => _process = bootstrap.BootstrapOOPInfo();

        [HttpGet]
        public IActionResult OOPInfo(OOPInfoTypeEnum oopTypesEnum) =>
            _process.ProcessObjectOrientedProgrammingInfo(oopTypesEnum).AndThen(OnSuccess, OnError);

        private IActionResult OnError(ErrorCode errorCode) => BadRequest(errorCode);

        private IActionResult OnSuccess() => _process.ReadResultInfo().AndThen(Ok, () => OnError(ApiErrors.ApiErrors.UnableToReadResponse));
    }
}