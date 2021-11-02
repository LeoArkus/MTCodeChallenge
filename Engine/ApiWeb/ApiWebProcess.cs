using System.Collections.Generic;
using Commons;
using Domain.ApiWeb;
using static Commons.RailWayOrientation;
using static Commons.TryCommandResult;

namespace Engine.ApiWeb
{
    public class ApiWebProcess : IProcessApiWebInfo
    {
        private Optional<string> _result = Optional<string>.Create();

        public CommandResult<ErrorCode> ProcessApiWebInfo(ApiWebInfoEnum apiWebInfoTypeEnum) =>
            Railway(
                CommandResult<ErrorCode>.Create,
                () => GetApiWebInfo(apiWebInfoTypeEnum)
            );

        private CommandResult<ErrorCode> GetApiWebInfo(ApiWebInfoEnum apiWebInfoTypeEnum) =>
            TryEcEx(() => _result = Optional<string>.Create(_apiWebInfoDict[apiWebInfoTypeEnum]), ApiWebInfoErrors.InvalidApiWebTypeEnum.ErrorNum);

        private readonly Dictionary<ApiWebInfoEnum, string> _apiWebInfoDict = new()
        {
            { ApiWebInfoEnum.ApiWeb, ApiWebInfo },
            { ApiWebInfoEnum.ApiWebTestTools , ApiWebTestTools},
            { ApiWebInfoEnum.ApiWebErrorHandlerTools , ApiWebErrorTool},
            { ApiWebInfoEnum.ApiWebTestDrivenDevelopment , ApiWebTestDrivenDevelopment}
        };

        private const string ApiWebInfo = @"
            What is a WebAPI ?: The Web API is a framework for building web services, these web services use the HTTP protocol.
            How does it works ? : The Web API returns the data on request from the client, and it can be in the format XML or JSON.
        ";

        private const string ApiWebTestTools = @"
            Web Api Test Tools: There a variety of tools: such as Postman, RapidAPI, Katalon, Swagger etc.
        ";

        private const string ApiWebErrorTool = @"
            Web Api Error Handling: Using a common static class that does a try-catch internally.
        ";

        private const string ApiWebTestDrivenDevelopment = @"
            WebA Api Test Driven Delopment:  Is software development approach in which test cases are developed to specify and validate what the code will do. 
            In simple terms, test cases for each functionality are created and tested first and if the test fails then the new code is written in order to pass the test and making code simple and bug-free.
        ";

        public Optional<string> ReadResultInfo() => _result;
    }
}