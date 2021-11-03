using CodeChallengeBootstrap;
using Endpoints.Controllers;
using Xunit;
using Moq;

namespace CodeChallengeApiTests.ApiWeb
{
    public class WebApiTests
    {
        [Fact]
        public void WhenApiWebInfoAllOk()
        {
            var subject = new ApiWebInfoController(new BootstrapApiWeb());
        }
    }
}
