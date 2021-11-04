using System.Collections.Generic;
using Commons;
using Domain.SOLID;
using static Commons.RailWayOrientation;
using static Commons.TryCommandResult;

namespace Engine.SOLID
{
    public class SolidPrinciplesProcess : IProcessSolidPrinciplesInfo
    {
        private Optional<string> _result = Optional<string>.Create();

        public CommandResult<ErrorCode> SolidPrinciplesInfoProcess(SolidPrinciplesTypes solidPrinciplesTypeEnum) =>
            Railway(
                CommandResult<ErrorCode>.Create,
                ()=> GetSolidPrincipleInfo(solidPrinciplesTypeEnum)
            );

        private CommandResult<ErrorCode> GetSolidPrincipleInfo(SolidPrinciplesTypes solidPrinciplesTypeEnum) =>
            TryEcEx(() => _result = Optional<string>.Create(_solidPrinciplesInfoDict[solidPrinciplesTypeEnum]), SolidPrincipleInfoErrors.InvalidSolidPrinciple.ErrorNum);

        private readonly Dictionary<SolidPrinciplesTypes, string> _solidPrinciplesInfoDict = new()
        {
            {SolidPrinciplesTypes.SOLID,"It is the acronym for the 5 basic principles of the OOP."},
            {SolidPrinciplesTypes.SingleResponsibility, "SRP: 'A class should have only one reason to change.'"},
            {SolidPrinciplesTypes.OpenClose,"OCP: 'Software entities should be open for extension but closed for modification.'"},
            {SolidPrinciplesTypes.LiskovSubstitution,"LSK: 'If S is subtype of T, objects of type T should be replaceable with objects of type S without altering the program/result or causing an unwanted behaviour.'"},
            {SolidPrinciplesTypes.InterfaceSegregation,"ISP: 'Clients should not be forced to depend on methods they do not use.'"},
            { SolidPrinciplesTypes.DependencyInversion, @"DIP: High level modules, should not depend on low level modules. Both should depend on abstractions. 
            Abstractions should not depend on details. Details should not depend on abstractions."}
        };

        public Optional<string> ReadResultInfo() => _result;
    }
}