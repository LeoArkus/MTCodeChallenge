using Domain.SOLID;
using Engine.SOLID;

namespace CodeChallengeBootstrap
{
    public interface IBootstrapSolidPrinciples
    {
        IProcessSolidPrinciplesInfo BootstrapSolidPrinciplesInfo();
    }
    
    public class BootstrapSolidPrinciples : IBootstrapSolidPrinciples
    {
        public IProcessSolidPrinciplesInfo BootstrapSolidPrinciplesInfo() => new SolidPrinciplesProcess();
    }
}