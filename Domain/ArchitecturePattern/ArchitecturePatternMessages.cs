namespace Domain.ArchitecturePattern
{
    public struct ArchitecturePatternMessage
    {
        public ArchitecturePatternTypeEnum ArchitecturePatternType { get; set; }
    }

    public enum ArchitecturePatternTypeEnum
    {
        MVC,
        Hexagonal
    }
}