using Commons;

namespace Domain.SOLID
{
    public interface IProcessSolidPrinciplesInfo
    {
        CommandResult<ErrorCode> SolidPrinciplesInfoProcess(SolidPrinciplesTypes solidPrinciplesTypeEnum);
        Optional<string> ReadResultInfo();
    }
}