using Microsoft.EntityFrameworkCore;
using Searching_Tool_Assignment.IRepositories;
using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Repositories
{
    public class SourceRepository : Repository<Source>,ISourceRepository
    {
        private readonly ApplicationDbContext _context;

        public SourceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> SourceExists(string sourceName)
        {
            var sources = _context.Sources.AsNoTracking();
            if (await sources.Where(x => x.Name == sourceName).SingleOrDefaultAsync() is not null)
                return true;
            return false;
        }

        public async Task<Source?> Get(string sourceName)
        {
            var sources = _context.Sources.AsNoTracking();
            return await sources.Where(x => x.Name == sourceName).SingleOrDefaultAsync();
        }
    }
}
