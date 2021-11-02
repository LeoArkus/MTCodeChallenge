using Commons;

namespace Engine.AccessModifiers
{
    public static class AccessModifiersInfoErrors
    {
        public static ErrorCode InvalidAccessModifier = new ErrorCode("Invalid Access Modifier", AccessModifiersErrorsEnum.InvalidAccessModifier);
        
        private enum AccessModifiersErrorsEnum
        {
            InvalidAccessModifier
        }
    }
}