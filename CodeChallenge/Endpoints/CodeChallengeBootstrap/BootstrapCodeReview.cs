using Domain.CodeReview;
using Engine.CodeReview;

namespace CodeChallengeBootstrap
{
    public interface IBootstrapCodeReview
    {
        IProcessCodeReview BootstrapCodeReviewInfoProcess();
    }
    
    public class BootstrapCodeReview : IBootstrapCodeReview
    {
        public IProcessCodeReview BootstrapCodeReviewInfoProcess() => new CodeReviewInfoProcess();
    }
}