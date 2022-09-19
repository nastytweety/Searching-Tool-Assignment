using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.IRepositories
{
    public interface ISourceRepository : IRepository<Source>
    {
        Task<bool> SourceExists(string sourceName);

        Task<Source> Get(string sourceName);
    }
}
