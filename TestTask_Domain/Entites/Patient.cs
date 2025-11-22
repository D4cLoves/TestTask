using TestTask_Domain.ValueObject;

namespace TestTask_Domain.Entites;

public class Patient 
{
    public Guid Id { get; private set; }
    public FullName Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Guid DoctorId { get; private set; }

    private Patient(){}
    
    public Patient(FullName name, DateTime birthDate, Guid doctorId)
    {
        Id = Guid.NewGuid();
        Name = name;
        BirthDate = birthDate;
        DoctorId = doctorId;
    }
    
    public void UpdateName(FullName NewName) => Name = NewName;
    public void UpdateBirthDate(DateTime NewBirthDate) => BirthDate = NewBirthDate;
}