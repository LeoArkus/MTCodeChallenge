using Commons;

namespace Domain.ArchitecturePattern
{
    public interface IProcessArchitecturePatternInfo
    {
        CommandResult<ErrorCode> ArchitecturePatternInfoProcess(ArchitecturePatternTypeEnum architecturePatternTypeEnum);
        Optional<string> ReadArchitecturePatternInfo();
    }
}