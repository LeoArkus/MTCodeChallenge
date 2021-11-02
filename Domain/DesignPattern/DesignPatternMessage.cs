namespace Domain.DesignPattern
{
    public class DesignPatternMessage
    {
        public DesignPatternInfoType DesignPatternInfoTypeEnum { get; set; }
    }

    public enum DesignPatternInfoType
    {
        Creational,
        Structural,
        Behavioral
    }
}