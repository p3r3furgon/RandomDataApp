using B1ask1.DataAccess;
using B1Task1.Interfaces.Repositories;
using B1Task1.Models;
using Microsoft.EntityFrameworkCore;

namespace B1Task1.DataAccess.Repositories
{


    public class RandomDataRepository : IRandomDataRepository
    {
        private readonly RandomDataDbContext _context;

        public RandomDataRepository(RandomDataDbContext context)
        {
            _context = context;
        }

        public async Task<List<RandomDataEntry>> Get(int page, int pageSize)
        {
            return await _context.RandomDataEntries
                .OrderBy(d => d.Id)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<RandomDataEntry>> Get()
        {
            return await _context.RandomDataEntries.ToListAsync();
        }
        public async Task<RandomDataEntry?> GetById(int id)
        {
            return await _context.RandomDataEntries
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task AddRange(List<RandomDataEntry> randomDataEntries)
        {
            await _context.RandomDataEntries.AddRangeAsync(randomDataEntries);
            await _context.SaveChangesAsync();
        }

        public async Task Add(RandomDataEntry randomDataEntries)
        {
            await _context.RandomDataEntries.AddAsync(randomDataEntries);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAll()
        {
            _context.RemoveRange(_context.RandomDataEntries);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.RemoveRange(_context.RandomDataEntries.Where(e => e.Id == id));
            await _context.SaveChangesAsync();
        }

    }
}
