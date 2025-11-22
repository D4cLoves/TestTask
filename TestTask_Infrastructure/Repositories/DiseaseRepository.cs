using Microsoft.EntityFrameworkCore;
using TestTask_Domain.Entites;
using TestTask_Domain.Interfaces;
using TestTask_Infrastructure.Data;

namespace TestTask_Infrastructure.Repositories;

public class DiseaseRepository : IDieseasRepository
{
    private readonly ApplicationDbContext _context;
    public DiseaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Disease>> GetDiseases()
    {
        return await _context.Diseases.ToListAsync();
    }
}