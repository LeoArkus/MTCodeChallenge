using CodeChallengeBootstrap;
using Commons;
using Domain.ArchitecturePattern;
using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Controllers
{
    [ApiController]
    [Route("api/ArchitecturePatternInfo")]
    public class ArchitecturePatternInfoController : Controller
    {
        private readonly IProcessArchitecturePatternInfo _process;

        public ArchitecturePatternInfoController(IBootstrapArchitecturePattern bootstrap) => _process = bootstrap.BootstrapArchitecturePatternInfo();

        [HttpGet]
        public IActionResult ArchitecturePatternInfo(ArchitecturePatternTypeEnum architecturePatternTypeEnum) =>
            _process.ArchitecturePatternInfoProcess(architecturePatternTypeEnum).AndThen(OnSuccess, OnError);

        private IActionResult OnError(ErrorCode errorCode) => BadRequest(errorCode);

        private IActionResult OnSuccess() => _process.ReadArchitecturePatternInfo().AndThen(Ok, () => OnError(ApiErrors.ApiErrors.UnableToReadResponse));
    }
}