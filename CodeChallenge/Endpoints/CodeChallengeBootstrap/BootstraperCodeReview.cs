using Domain.CodeReview;
using Engine.CodeReview;

namespace CodeChallengeBootstrap
{
    public interface IBootstrapperCodeReview
    {
        IProcessCodeReview BootstrapCodeReviewInfo();
    }
    
    public class BootstrapperCodeReview : IBootstrapperCodeReview
    {
        public IProcessCodeReview BootstrapCodeReviewInfo() => new CodeReviewInfoProcess();
    }
}