using Domain.ApiWeb;
using Engine.ApiWeb;
using Xunit;

namespace EngineTests.ApiWeb
{
    public class ApiWebInfoProcessTests
    {
        [Fact]
        public void WhenApiWebInfoSuccess()
        {
            var subject = new ApiWebProcess();
            var result = subject.ProcessApiWebInfo(ApiWebInfoEnum.ApiWeb);
            Assert.True(result.IsSuccess());
            Assert.True(result.Errors().IsNothing());
        }
        
        [Fact]
        public void WhenApiWebInfoFail()
        {
            var subject = new ApiWebProcess();
            var result = subject.ProcessApiWebInfo(ApiWebInfoEnum.ApiWebException);
            Assert.True(!result.IsSuccess());
            result.Errors().AndThen(x => Assert.Equal(x.ErrorNum, ApiWebInfoErrors.InvalidApiWebTypeEnum.ErrorNum), () => Assert.True(true));
        }
    }
}
