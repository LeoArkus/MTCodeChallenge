using System.Collections.Generic;
using Commons;

namespace Domain.AccessModifiers
{
    public interface IProcessAccessModifiers
    {
        CommandResult<ErrorCode> ReadAccessModifiersInfo(AccessModifiersTypeEnum accessModifiersTypeEnum);
        Optional<string> ReadResultInfo();
    }
}