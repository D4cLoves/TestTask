using Microsoft.EntityFrameworkCore;
using TestTask_Domain.Entites;
using TestTask_Domain.Interfaces;
using TestTask_Infrastructure.Data;

namespace TestTask_Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _context;
    public DoctorRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Doctor>> GetDoctorsBySpeciality(string specialty)
    {
        return await _context.Doctors.Where(d => d.Specialty.ToLower().Contains(specialty.ToLower().Trim()))
            .ToListAsync();
    }
}