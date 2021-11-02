using System.Collections.Generic;
using Commons;
using Domain.OOP;
using static Commons.RailWayOrientation;
using static Commons.TryCommandResult;

namespace Engine.OOP
{
    public class OOPProcess : IProcessOOPInfo
    {
        private Optional<string> _result = Optional<string>.Create();
        
        public CommandResult<ErrorCode> ProcessObjectOrientedProgrammingInfo(OOPInfoTypeEnum oopInfoTypeEnum) =>
            Railway(
                CommandResult<ErrorCode>.Create,
                ()=> GetObjectOrientedProgrammingInfo(oopInfoTypeEnum)
            );

        private CommandResult<ErrorCode> GetObjectOrientedProgrammingInfo(OOPInfoTypeEnum oopInfoTypeEnum) =>
            TryEcEx(() => _result = Optional<string>.Create(_objectOrientedProgrammingDict[oopInfoTypeEnum]), OopInfoErrors.InvalidOopInfo.ErrorNum);

        public Optional<string> ReadResultInfo() => _result;

        private readonly Dictionary<OOPInfoTypeEnum, string> _objectOrientedProgrammingDict = new()
        {
            { OOPInfoTypeEnum.Class , "It's the 'skeleton' of an object, where the properties, fields, methods etc of an object are defined."},
            { OOPInfoTypeEnum.Inheritance , @"When class B is derived from class A it is inheriting, hence class B can now use/access all of the properties of class A,
            all of the fields, properties,  based on their accessibility levels."},
            { OOPInfoTypeEnum.Interface , "An Interface is an abstraction of an object. Here are declared all of the properties and methods that it's concrete class must implement."},
            { OOPInfoTypeEnum.Polymorphism , "Polymorphism means the ability to take different forms. It's the ability of a class to override or overload the behaviour of it's parent class."}
        };
    }
}