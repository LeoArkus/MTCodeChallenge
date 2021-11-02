using Commons;

namespace Engine.ArchitecturePattern
{
    public static class ArchitecturePatternErrors
    {
        public static ErrorCode InvalidArchitecturePattern = new ErrorCode("Invalid Architecture Pattern", ArchitecturePatternErrorsEnum.InvalidArchitecturePattern);
        
        private enum ArchitecturePatternErrorsEnum
        {
            InvalidArchitecturePattern
        }
    }
}