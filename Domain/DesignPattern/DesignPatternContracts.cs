using Commons;

namespace Domain.DesignPattern
{
    public interface IProcessDesignPatternInfo
    {
        CommandResult<ErrorCode> ProcessDesignPatternInfo(DesignPatternInfoType message);
        Optional<string> ReadResultInfo();
    }
}