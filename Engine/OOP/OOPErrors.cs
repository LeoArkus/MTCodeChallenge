using Commons;

namespace Engine.OOP
{
    public static class OopInfoErrors
    {
        public static ErrorCode InvalidOopInfo = new ErrorCode("Invalid OOP Info", OopInfoErrorsEnum.InvalidOopInfo);
        
        private enum OopInfoErrorsEnum
        {
            InvalidOopInfo
        }
    }
}