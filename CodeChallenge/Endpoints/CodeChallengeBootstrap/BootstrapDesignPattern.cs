using Domain.DesignPattern;
using Engine.DesignPattern;

namespace CodeChallengeBootstrap
{
    public interface IBootstrapDesignPattern
    {
        IProcessDesignPatternInfo BootstrapDesignPatternInfo();
    }
    
    public class BootstrapDesignPattern : IBootstrapDesignPattern
    {
        public IProcessDesignPatternInfo BootstrapDesignPatternInfo() => new DesignPatternInfoProcess();
    }
}