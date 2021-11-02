using Commons;

namespace Domain.ApiWeb
{
    public interface IProcessApiWebInfo
    {
        CommandResult<ErrorCode> ProcessApiWebInfo(ApiWebInfoEnum apiWebInfoTypeEnum);
        Optional<string> ReadResultInfo();
    }
}