using Microsoft.EntityFrameworkCore;
using TestTask_Domain.Entites;
using TestTask_Domain.Interfaces;
using TestTask_Domain.ValueObject;
using TestTask_Infrastructure.Data;

namespace TestTask_Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _context;
    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Patient> GetPatientOnId(Guid id)
    {
        return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Patient>> GetPatients()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task UpdatePatientNameAsync(Guid id, FullName newName)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        if (patient != null)
        {
            patient.UpdateName(newName);
            await _context.SaveChangesAsync();
        }
    }
}