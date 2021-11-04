using System.Collections.Generic;
using System.Net;
using CodeChallengeBootstrap;
using Commons;
using Domain.ApiWeb;
using Endpoints.ApiErrors;
using Endpoints.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;

namespace CodeChallengeApiTests.ApiWeb
{
    public class WebApiTests
    {
        private readonly ErrorCode _error = new ErrorCode("Error","Error");

        [Fact]
        public void WhenApiWebInfoProcessFail()
        {
            var mBootstrap = new Mock<IBootstrapApiWeb>();
            var mProcess = new Mock<IProcessApiWebInfo>();
            mProcess.Setup(x => x.ProcessApiWebInfo(It.IsAny<ApiWebInfoEnum>())).Returns(CommandResult<ErrorCode>.Create(_error));
            mProcess.Setup(x => x.ReadResultInfo()).Returns(Optional<string>.Create());
            mBootstrap.Setup(x => x.BootstrapApiWebInfo()).Returns(mProcess.Object);
            var subject = new ApiWebInfoController(mBootstrap.Object);
            var result = subject.ApiWebInfo(ApiWebInfoEnum.ApiWeb) as ObjectResult;
            var error = (ErrorCode) result.Value;
            
            mProcess.Verify(x=> x.ProcessApiWebInfo(It.IsAny<ApiWebInfoEnum>()), Times.Once);
            mProcess.Verify(x=> x.ReadResultInfo(), Times.Never);
            mBootstrap.Verify(x=> x.BootstrapApiWebInfo(), Times.Once);
            
            Assert.NotEqual((int) HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(_error.ErrorNum,error.ErrorNum );
        }
        
        [Fact]
        public void WhenApiWebInfoProcessReadResultFail()
        {
            var mBootstrap = new Mock<IBootstrapApiWeb>();
            var mProcess = new Mock<IProcessApiWebInfo>();
            mProcess.Setup(x => x.ProcessApiWebInfo(It.IsAny<ApiWebInfoEnum>())).Returns(CommandResult<ErrorCode>.Create());
            mProcess.Setup(x => x.ReadResultInfo()).Returns(Optional<string>.Create());
            mBootstrap.Setup(x => x.BootstrapApiWebInfo()).Returns(mProcess.Object);
            var subject = new ApiWebInfoController(mBootstrap.Object);
            var result = subject.ApiWebInfo(ApiWebInfoEnum.ApiWeb) as ObjectResult;
            var error = (ErrorCode) result.Value;
            
            mProcess.Verify(x=> x.ProcessApiWebInfo(It.IsAny<ApiWebInfoEnum>()), Times.Once);
            mProcess.Verify(x=> x.ReadResultInfo(), Times.Once);
            mBootstrap.Verify(x=> x.BootstrapApiWebInfo(), Times.Once);
            
            Assert.NotEqual((int) HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(ApiErrors.UnableToReadResponse.ErrorNum,error.ErrorNum);
        }
        
        [Fact]
        public void WhenApiWebInfoProcessSuccess()
        {
            var mBootstrap = new Mock<IBootstrapApiWeb>();
            var mProcess = new Mock<IProcessApiWebInfo>();
            mProcess.Setup(x => x.ProcessApiWebInfo(It.IsAny<ApiWebInfoEnum>())).Returns(CommandResult<ErrorCode>.Create);
            mProcess.Setup(x => x.ReadResultInfo()).Returns(Optional<string>.Create("Success"));
            mBootstrap.Setup(x => x.BootstrapApiWebInfo()).Returns(mProcess.Object);
            var subject = new ApiWebInfoController(mBootstrap.Object);
            var result = subject.ApiWebInfo(ApiWebInfoEnum.ApiWeb) as ObjectResult;
            var errors = result.Value as List<ErrorCode>;
            
            mProcess.Verify(x=> x.ProcessApiWebInfo(It.IsAny<ApiWebInfoEnum>()), Times.Once);
            mProcess.Verify(x=> x.ReadResultInfo(), Times.Once);
            mBootstrap.Verify(x=> x.BootstrapApiWebInfo(), Times.Once);
            
            Assert.Equal((int) HttpStatusCode.OK, result.StatusCode);
            Assert.Null(errors);
        }
    }
}
