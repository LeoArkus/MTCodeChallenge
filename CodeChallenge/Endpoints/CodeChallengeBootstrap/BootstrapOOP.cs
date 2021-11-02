using Domain.OOP;
using Engine.OOP;

namespace CodeChallengeBootstrap
{
    public interface IBootstrapOOP
    {
        IProcessOOPInfo BootstrapOOPInfo();
    }
    
    public class BootstrapOOP: IBootstrapOOP
    {
        public IProcessOOPInfo BootstrapOOPInfo() => new OOPProcess();
    }
}