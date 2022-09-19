using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Repositories
{
    public interface ICurrencyrepository
    {
        Task<IEnumerable<Currency>> GetAll();
    }
}
