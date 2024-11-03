namespace B1Task1.Interfaces.Services
{
    public interface IRandomDataFilesGenerationService
    {
        Task<int> CombineFiles(IFormFile file1, IFormFile file2, string outputFile, string filter = "");
        Task GenerateFiles(int fileCount, int lineCount);
    }
}
