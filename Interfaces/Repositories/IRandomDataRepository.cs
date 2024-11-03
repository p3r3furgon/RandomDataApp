using B1Task1.Models;

namespace B1Task1.Interfaces.Repositories
{
    public interface IRandomDataRepository
    {
        Task Add(RandomDataEntry randomDataEntries);
        Task AddRange(List<RandomDataEntry> randomDataEntries);
        Task Delete(int id);
        Task DeleteAll();
        Task<List<RandomDataEntry>> Get(int page, int pageSize);
        Task<List<RandomDataEntry>> Get();
        Task<RandomDataEntry?> GetById(int id);
    }
}
