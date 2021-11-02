using Commons;

namespace Engine.ApiWeb
{
    public static class ApiWebInfoErrors
    {
        public static ErrorCode InvalidApiWebTypeEnum = new ErrorCode("Invalid Api Web Type", ApiWebTypeEnumErrorsEnum.InvalidApiWebTypeEnum);
        
        private enum ApiWebTypeEnumErrorsEnum
        {
            InvalidApiWebTypeEnum
        }
    }
}