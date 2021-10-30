using Domain.ArchitecturePattern;
using Engine.ArchitecturePattern;

namespace CodeChallengeBootstrap
{
    public interface IBootstrapArchitecturePattern
    {
        IProcessArchitecturePatternInfo BootstrapArchitecturePatternInfo();
    }
    
    public class BootstrapArchitecturePattern : IBootstrapArchitecturePattern
    {
        public IProcessArchitecturePatternInfo BootstrapArchitecturePatternInfo() => new ArchitecturePatternProcess();
    }
}