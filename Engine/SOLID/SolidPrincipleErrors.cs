using Commons;

namespace Engine.SOLID
{
    public static class SolidPrincipleInfoErrors
    {
        public static ErrorCode InvalidSolidPrinciple = new ErrorCode("Invalid Solid principle", SolidPrincipleErrorsEnum.InvalidSolidPrinciple);
        
        private enum SolidPrincipleErrorsEnum
        {
            InvalidSolidPrinciple
        }
    }
}