namespace TestTask_Domain.ValueObject;

public class FullName
{
    public string Value { get; }

    public FullName(string value)
    {
        Value = value;
    }

    public static FullName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("ФИО не может быть пустым");

        var trimmed = value.Trim();
        
        if (trimmed.Length < 2)
            throw new ArgumentException("Слишком короткое имя");

        return new FullName(trimmed);
    }
    
    public override string ToString() => Value;
}