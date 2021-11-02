using CodeChallengeBootstrap;
using Commons;
using Domain.SOLID;
using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Controllers
{
    [ApiController]
    [Route("api/SolidPrinciplesInfo")]
    public class SolidPrinciplesInfoController : Controller
    {
        private readonly IProcessSolidPrinciplesInfo _process;

        public SolidPrinciplesInfoController(IBootstrapSolidPrinciples bootstrap) => _process = bootstrap.BootstrapSolidPrinciplesInfo();

        [HttpGet]
        public IActionResult DesignPatternInfo(SolidPrinciplesTypes solidPrinciplesTypesEnum) =>
            _process.SolidPrinciplesInfoProcess(solidPrinciplesTypesEnum).AndThen(OnSuccess, OnError);

        private IActionResult OnError(ErrorCode errorCode) => BadRequest(errorCode);

        private IActionResult OnSuccess() => _process.ReadResultInfo().AndThen(Ok, () => OnError(ApiErrors.ApiErrors.UnableToReadResponse));
    }
}