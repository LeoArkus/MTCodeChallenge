using Commons;

namespace Endpoints.ApiErrors
{
    public static class ApiErrors
    {
        public static ErrorCode UnableToReadResponse = new ErrorCode("Unable To Read Response", ApiErrorsEnum.UnableToReadResponse);
        
        private enum ApiErrorsEnum
        {
            UnableToReadResponse
        }
    }
}