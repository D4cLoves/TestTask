using TestTask_Domain.ValueObject;

namespace TestTask_Domain.Entites;

public class Doctor
{
    public Guid Id { get; private set; }
    public FullName Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    
    private Doctor(){}

    public Doctor(FullName name, DateTime birthDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        BirthDate = birthDate;
    }
    
    public void UpdateName(FullName name) => Name = name;
    public void UpdateBirthDate(DateTime birthDate) => BirthDate = birthDate;
}