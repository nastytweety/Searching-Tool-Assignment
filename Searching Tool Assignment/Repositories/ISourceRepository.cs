using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Repositories
{
    public interface ISourceRepository : IRepository<Source>
    {
        Task<bool> SourceExists(string sourceName);

        Task<Source> Get(string sourceName);
    }
}
