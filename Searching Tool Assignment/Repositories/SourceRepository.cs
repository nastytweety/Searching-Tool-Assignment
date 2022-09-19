using Microsoft.EntityFrameworkCore;
using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Repositories
{
    public class SourceRepository : ISourceRepository
    {
        private readonly ApplicationDbContext _context;

        public SourceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SourceExists(string sourceName)
        {
            if(await _context.Sources.Where(x => x.Name == sourceName).SingleOrDefaultAsync()!=null)
                return true;
            else
                return false;
        }

        public async Task<Source> Get(string sourceName)
        {
            return await _context.Sources.Where(x => x.Name == sourceName).SingleOrDefaultAsync();
        }
    }
}
