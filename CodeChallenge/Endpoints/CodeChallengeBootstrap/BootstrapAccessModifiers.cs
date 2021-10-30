using Domain.AccessModifiers;
using Engine.AccessModifiers;

namespace CodeChallengeBootstrap
{
    public interface IBootstrapAccessModifiers
    {
        IProcessAccessModifiers BootstrapAccessModifiersProcess();
    }
    
    public class BootstrapAccessModifiers : IBootstrapAccessModifiers
    {
        public IProcessAccessModifiers BootstrapAccessModifiersProcess() => new AccessModifiersProcess();
    }
}