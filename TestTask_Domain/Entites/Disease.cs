namespace TestTask_Domain.Entites;

public class Disease
{
    public Guid Id { get; private set; }    
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    
    private Disease(){}

    public Disease(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException(nameof(name)) : name.Trim();
        Description = string.IsNullOrWhiteSpace(description) ? throw new ArgumentException(nameof(description)) : description.Trim();
    }
    
    public void UpdateName(string name) => Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException(nameof(name)) : name.Trim();
    public void UpdateDescription(string description) => Description = string.IsNullOrWhiteSpace(description) ? throw new ArgumentException(nameof(description)) : description.Trim();
}