using CodeChallengeBootstrap;
using Domain.CodeReview;
using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Controllers
{
    [ApiController]
    [Route("api/CodeReviewInfo")]
    public class CodeReviewInfoController : Controller
    {
        private readonly IProcessCodeReview _process;

        public CodeReviewInfoController(IBootstrapperCodeReview bootstrap) => _process = bootstrap.BootstrapCodeReviewInfo();

        [HttpGet]
        public IActionResult CodeReviewInfo() => Ok(_process.ReadCodeReviewInfo());
    }
}