using System.Collections.Generic;
using Commons;
using Domain.DesignPattern;
using static Commons.RailWayOrientation;
using static Commons.TryCommandResult;

namespace Engine.DesignPattern
{
    public class DesignPatternInfoProcess : IProcessDesignPatternInfo
    {
        private Optional<string> _result = Optional<string>.Create();

        public CommandResult<ErrorCode> ProcessDesignPatternInfo(DesignPatternInfoType designPatternType) =>
            Railway(
                CommandResult<ErrorCode>.Create,
                ()=> GetDesignPatternInfo(designPatternType)
            );

        private CommandResult<ErrorCode> GetDesignPatternInfo(DesignPatternInfoType designPatternType) =>
            TryEcEx(() => _result = Optional<string>.Create(_designPatternInfoDict[designPatternType]), DesignPatternErrors.InvalidDesignPattern.ErrorNum);

        private readonly Dictionary<DesignPatternInfoType, string> _designPatternInfoDict = new Dictionary<DesignPatternInfoType, string>()
        {
            {DesignPatternInfoType.Creational, CreationalPatterns},
            {DesignPatternInfoType.Structural, StructuralPatterns},
            {DesignPatternInfoType.Behavioral, BehavioralPatterns}
        };

        public Optional<string> ReadResultInfo() => _result;

        private const string CreationalPatterns = @"
            Builder: 'Separate the construction of a complex object from its representation so that the same construction process can create diferent representations.'
            In other words, for this pattern you need to dessign a class that has the unique responsability of create and return the objects of T type, useful in the case a type T needs to have a bunch of constructors.

            Factory: 'Define an interface for creating an object, but let subclasses decide which class to instantiate.'
            For this pattern you need to create an abstract class with N abstract methods which its derived classes override and can return the desired class intance.
            
            Prototype: 'Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.'
            By implementing this pattern we are going to have a class which its sole purpose is to clone all the members of an object and return a new instance of it.
            
            Singleton: 'Ensure a class only has one instance, and provide a global point of access to it.'
            This pattern as its name implies its helpful when you want to ensure a sole instance of a class for example: game manager, logging, caching, pool etc.
        ";

        private const string StructuralPatterns = @"
            Adapter: 'Convert the interface of a class into another interface client expects.'
            In other words this pattern allows two or more classes to be 'compatible' thanks to a wrapper (class A) that usually is passed in the constructor of class B,
            then all of the logic of 'adapting' class A is done in the class B.

            Facade: 'Provide a unified interface to a set of interfaces in a subsystem. Facade defines a higher level of interface that makes the subsystem easier to use.'
            In summary, this pattern allows us to 'manage better' or 'improve interaction' with a complex subsystem(s) that has a bunch of interfaces by using the unified
            interface that has the only task to interact with this complex subsystem, so the client only needs to 'know' the unified interface instead of all the interfaces
            of the complex susbsystem.

            Proxy: 'Provide a surrogate or placeholder for other object to control access to it.'
            The proxy pattern allow us to control the instance of N object with the proxy which is a concrete class that has the instance of the object that we want to control. 
        ";

        private const string BehavioralPatterns = @"
            Command: 'Encapsulates a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support for
            undoable operations. Aka: Transaction.'
            In summary this pattern allow us to pass functions or operations represented as objects with its type (functional programming).

            Mediator: 'Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring from each
            other explicitly, and it lets you vary their iteraction independently.'
            The mediator let us decouple a N number of classes by creating a mediator which has a mutual reference against these classes (mediator has reference of
            N classes while the classes has the reference of the mediator) and also add new functionality if needed.

            Observer: 'Define a one to many dependency between objects so that when one object changes state, all its dependencies are notified and update automatically.'
            This pattern allows to define a mechanism of subscription that notifies N objects of any event that happens to the object that they are 'observing'.

            State: 'Allow an object to alter its behaviour when its internal state changes. The object will appear to change its class.'
            Basically what this pattern describes as its name implies, its the creation of a state machine.
        ";
    }
}