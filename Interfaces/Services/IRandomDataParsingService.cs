using B1Task1.Models;

namespace B1Task1.Interfaces.Services
{
    public interface IRandomDataParsingService
    {
        Task<List<RandomDataEntry>> Parse(IFormFile file);
        RandomDataEntry ParseRandomDataLine(string line);
    }
}
