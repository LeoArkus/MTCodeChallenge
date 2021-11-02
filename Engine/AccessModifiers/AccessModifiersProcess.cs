using System.Collections.Generic;
using Commons;
using Domain.AccessModifiers;
using static Commons.TryCommandResult;

namespace Engine.AccessModifiers
{
    public class AccessModifiersProcess : IProcessAccessModifiers
    {
        private Optional<string> _result = Optional<string>.Create();

        public CommandResult<ErrorCode> ReadAccessModifiersInfo(AccessModifiersTypeEnum accessModifiersTypeEnum) =>
            RailWayOrientation.Railway(
                CommandResult<ErrorCode>.Create,
                ()=> GetAccessModifiersInfo(accessModifiersTypeEnum)
            );

        private CommandResult<ErrorCode> GetAccessModifiersInfo(AccessModifiersTypeEnum accessModifiersTypeEnum) =>
            TryEcEx(() => _result = Optional<string>.Create(_accessModifiersInfoDict[accessModifiersTypeEnum]), AccessModifiersInfoErrors.InvalidAccessModifier.ErrorNum);

        private readonly Dictionary<AccessModifiersTypeEnum, string> _accessModifiersInfoDict = new()
        {
            { AccessModifiersTypeEnum.Public , "It can be accessed by any other code in the same assembly or another assembly that references it."},
            { AccessModifiersTypeEnum.Private , "It can be accessed only by code in the same class or struct."},
            { AccessModifiersTypeEnum.Protected , "It can be accessed only by code in the same class, or in a class that is derived from that class."},
            { AccessModifiersTypeEnum.Internal , "It can be accessed by any code in the same assembly, but not from another assembly."},
            { AccessModifiersTypeEnum.ProtectedInternal , "It can be accessed by any code in the assembly in which it's declared, or from within a derived class in another assembly."},
            { AccessModifiersTypeEnum.PrivateProtected , "It can be accessed only within its declaring assembly, by code in the same class or in a type that is derived from that class."}
        };

        public Optional<string> ReadResultInfo() => _result;
    }
}