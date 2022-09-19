using Microsoft.EntityFrameworkCore;
using Searching_Tool_Assignment.IRepositories;
using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Repositories
{
    public class CurrencyRepository : Repository<Currency>,ICurrencyrepository
    {
        private readonly ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
