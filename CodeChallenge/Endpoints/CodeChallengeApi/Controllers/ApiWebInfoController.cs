using CodeChallengeBootstrap;
using Commons;
using Domain.ApiWeb;
using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Controllers
{
    [ApiController]
    [Route("api/ApiWebInfo")]
    public class ApiWebInfoController : Controller
    {
        private readonly IProcessApiWebInfo _process;

        public ApiWebInfoController(IBootstrapApiWeb bootstrap) => _process = bootstrap.BootstrapApiWebInfo();

        [HttpGet]
        public IActionResult ApiWebInfo(ApiWebInfoEnum apiWebInfoEnum) =>
            _process.ProcessApiWebInfo(apiWebInfoEnum).AndThen(OnSuccess, OnError);

        private IActionResult OnError(ErrorCode errorCode) => BadRequest(errorCode);

        private IActionResult OnSuccess() => _process.ReadResultInfo().AndThen(Ok, () => OnError(ApiErrors.ApiErrors.UnableToReadResponse));
    }
}