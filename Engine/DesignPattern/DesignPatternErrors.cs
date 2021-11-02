using Commons;

namespace Engine.DesignPattern
{
    public static class DesignPatternErrors
    {
        public static ErrorCode InvalidDesignPattern = new ErrorCode("Invalid Design Pattern", DesignPatternErrorsEnum.InvalidDesignPattern);
        
        private enum DesignPatternErrorsEnum
        {
            InvalidDesignPattern
        }
    }
}