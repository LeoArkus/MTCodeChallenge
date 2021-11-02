using Commons;

namespace Domain.OOP
{
    public interface IProcessOOPInfo
    {
        CommandResult<ErrorCode> ProcessObjectOrientedProgrammingInfo(OOPInfoTypeEnum oopInfoTypeEnum);
        Optional<string> ReadResultInfo();
    }
}