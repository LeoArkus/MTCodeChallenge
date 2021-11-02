using CodeChallengeBootstrap;
using Commons;
using Domain.DesignPattern;
using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Controllers
{
    [ApiController]
    [Route("api/DesignPatternInfo")]
    public class DesignPatternInfoController : Controller
    {
        private readonly IProcessDesignPatternInfo _process;

        public DesignPatternInfoController(IBootstrapDesignPattern bootstrap) => _process = bootstrap.BootstrapDesignPatternInfo();

        [HttpGet]
        public IActionResult DesignPatternInfo(DesignPatternInfoType designPatternTypeEnum) =>
            _process.ProcessDesignPatternInfo(designPatternTypeEnum).AndThen(OnSuccess, OnError);

        private IActionResult OnError(ErrorCode errorCode) => BadRequest(errorCode);

        private IActionResult OnSuccess() => _process.ReadResultInfo().AndThen(Ok, () => OnError(ApiErrors.ApiErrors.UnableToReadResponse));
    }
}