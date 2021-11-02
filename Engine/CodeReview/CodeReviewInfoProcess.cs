using Domain.CodeReview;

namespace Engine.CodeReview
{
    public class CodeReviewInfoProcess : IProcessCodeReview
    {
        public string ReadCodeReviewInfo() => CodeReviewInfo;

        private const string CodeReviewInfo = @"
            The code review is a 'good practice' among developers, where once each developer has finished their task/US, they need to create a pull request and then 
            schedule a meeting with their teammates to review all the changes and additions on which they worked on.
            This with two main reasons:
            1.- That all of the team mates known the most recent changes
            2.- Receive feedback on the code they want to push to the server branch
            3.- Make all the necesesary changes before submiting the code to the server
        ";
    }
}