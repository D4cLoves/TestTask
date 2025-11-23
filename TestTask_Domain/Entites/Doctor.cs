using TestTask_Domain.ValueObject;

namespace TestTask_Domain.Entites;

public class Doctor
{
    public Guid Id { get; private set; }
    public FullName Name { get; private set; }
    public string Specialty {get; private set;}
    public DateTime BirthDate { get; private set; }
    
    private Doctor(){}

    public Doctor(FullName name, string specialty, DateTime birthDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        Specialty = specialty;
        BirthDate = birthDate;
    }
    
    public void UpdateName(FullName name) => Name = name;
    public void UpdateSpecialty(string specialty) => Specialty = string.IsNullOrWhiteSpace(specialty) ? throw new ArgumentException(nameof(specialty)) : specialty.Trim();
    public void UpdateBirthDate(DateTime birthDate) => BirthDate = birthDate;
}