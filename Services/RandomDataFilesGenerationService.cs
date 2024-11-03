using B1Task1.Interfaces.Services;

namespace B1Task1.Services
{
    public class RandomDataFilesGenerationService : IRandomDataFilesGenerationService
    {
        private static readonly ThreadLocal<Random> _random = new ThreadLocal<Random>(() => new Random());

        public async Task GenerateFiles(int fileCount, int lineCount)
        {

            var tasks = new List<Task>();

            for (int i = 0; i < fileCount; i++)
            {
                int fileIndex = i;
                tasks.Add(Task.Run(async () =>
                {
                    var entries = new List<string>();

                    for (int j = 0; j < lineCount; j++)
                    {
                        entries.Add(GenerateRandomEntry());
                    }

                    await WriteToFile($"RandomDataFile_{fileIndex + 1}.txt", entries);
                }));
            }

            await Task.WhenAll(tasks);
        }

        private string GenerateRandomEntry()
        {
            var randomDataParts = new[]
            {
                GenerateRandomDate().ToString("dd.MM.yyyy"),
                GenerateRandomLatinChars(),
                GenerateRandomCyrillicChars(),
                GenerateRandomEvenNumber().ToString(),
                GenerateRandomDecimal().ToString("0.########")
            };
            return string.Join("||", randomDataParts);
        }

        private DateTime GenerateRandomDate()
        {
            var start = DateTime.Now.AddYears(-5);
            var end = DateTime.Now;
            var range = (end - start).Days;
            return start.AddDays(_random.Value.Next(range));
            ;
        }

        private string GenerateRandomLatinChars()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[_random.Value.Next(s.Length)]).ToArray());
        }

        private string GenerateRandomCyrillicChars()
        {
            const string chars = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдежзийклмнопрстуфхцчшщъыьэюя";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[_random.Value.Next(s.Length)]).ToArray());
        }

        private int GenerateRandomEvenNumber()
        {
            return _random.Value.Next(1, 50000000) * 2;
        }

        private decimal GenerateRandomDecimal()
        {
            return Math.Round((decimal)(_random.Value.NextDouble() * 19 + 1), 8);
        }

        private async Task WriteToFile(string fileName, List<string> entries)
        {
            var filesRootPath = Path.Combine(Directory.GetCurrentDirectory(), "Files");

            if (!Directory.Exists(filesRootPath))
            {
                Directory.CreateDirectory(filesRootPath);
            }

            var filePath = Path.Combine(filesRootPath, fileName);

            using (var writer = new StreamWriter(filePath))
            {
                foreach (var entry in entries)
                {
                    await writer.WriteLineAsync(entry);
                }
            }
        }
        public async Task<int> CombineFiles(IFormFile file1, IFormFile file2, string outputFile, string filter = "")
        {
            var filesRootPath = Path.Combine(Directory.GetCurrentDirectory(), "Files");
            int removedLinesNumber = 0;
            var combinedLines = new List<string>();
            using (var stream = new StreamReader(file1.OpenReadStream()))
            {
                var content = await stream.ReadToEndAsync();
                combinedLines.AddRange(content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList());
            }
            using (var stream = new StreamReader(file2.OpenReadStream()))
            {
                var content = await stream.ReadToEndAsync();
                combinedLines.AddRange(content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList());
            }

            if (!string.IsNullOrEmpty(filter))
            {
                var totalLinesNumber = combinedLines.Count();
                combinedLines = combinedLines.Where(line => !line.Contains(filter)).ToList();
                removedLinesNumber = totalLinesNumber - combinedLines.Count;
            }

            var outputFilePath = Path.Combine(filesRootPath, outputFile);

            File.WriteAllLines(outputFilePath, combinedLines);
            return removedLinesNumber;
        }
    }
}
