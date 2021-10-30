using System.Collections.Generic;
using Commons;
using Domain.ArchitecturePattern;
using static Commons.RailWayOrientation;
using static Commons.TryCommandResult;

namespace Engine.ArchitecturePattern
{
    public class ArchitecturePatternProcess : IProcessArchitecturePatternInfo
    {
        private Optional<string> _result = Optional<string>.Create();

        public CommandResult<ErrorCode> ArchitecturePatternInfoProcess(ArchitecturePatternTypeEnum architecturePatternTypeEnum) =>
            Railway(
                CommandResult<ErrorCode>.Create,
                ()=> GetArchitecturePatternInfo(architecturePatternTypeEnum)
            );

        private CommandResult<ErrorCode> GetArchitecturePatternInfo(ArchitecturePatternTypeEnum architecturePatternTypeEnum) => 
            TryEcEx(() => _result = Optional<string>.Create(_architecturePatternInfoDict[architecturePatternTypeEnum]), ArchitecturePatternErrors.InvalidArchitecturePattern.ErrorNum);

        private readonly Dictionary<ArchitecturePatternTypeEnum, string> _architecturePatternInfoDict = new()
        {
            { ArchitecturePatternTypeEnum.MVC , @"Acronym for Model, View, Controller, in summary the controller takes the user input which then passes it to
            Model whose work its to manage the necessary data (DB, bussiness logic, etc) and then sends the result back to the controller, then the controller validates the Model response
            to be either valid or contains an error, then passes it to the View which its unique task is to build the response in a readable form (HTML,CSS etc)
            and return it to the controller which final task is to show this view to the user."},
            { ArchitecturePatternTypeEnum.Hexagonal , @"Also known as ports and adapters or beehive, in summary this architecture divides the application in ports
            and different layers, which first layer has to be the domain, entities, repositories, then the business logic, then the controllers, and with the particularity that the
            layers in the bottom (inner layers) doesn't know anything (they are not referenced to each other) of the outer layers. Thanks to this it has a great flexibility in 
            terms of replaceability."}
        };  

        public Optional<string> ReadArchitecturePatternInfo() => _result;
    }
}