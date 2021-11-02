using Domain.ApiWeb;
using Engine.ApiWeb;

namespace CodeChallengeBootstrap
{
    public interface IBootstrapApiWeb
    {
        IProcessApiWebInfo BootstrapApiWebInfo();
    }
    
    public class BootstrapApiWeb : IBootstrapApiWeb
    {
        public IProcessApiWebInfo BootstrapApiWebInfo() => new ApiWebProcess();
    }
}