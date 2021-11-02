using CodeChallengeBootstrap;
using Commons;
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
        public IActionResult AccessModifiersInfo(AccessModifiersTypeEnum accessModifiersTypeEnum) =>
            _process.ReadAccessModifiersInfo(accessModifiersTypeEnum).AndThen(OnSuccess, OnError);
        
        private IActionResult OnError(ErrorCode errorCode) => BadRequest(errorCode);

        private IActionResult OnSuccess() => _process.ReadResultInfo().AndThen(Ok, () => OnError(ApiErrors.ApiErrors.UnableToReadResponse));
    }
}