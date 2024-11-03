using B1Task1.Interfaces.Services;
using B1Task1.Models;

namespace B1TestTask1.Services
{
    public class RandomDataParsingService : IRandomDataParsingService
    {
        public async Task<List<RandomDataEntry>> Parse(IFormFile file)
        {
            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                var content = await stream.ReadToEndAsync();
                var randomDataLines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                var randomDataEntries = new List<RandomDataEntry>();

                foreach (var line in randomDataLines)
                {
                    var randomDataEntry = ParseRandomDataLine(line);
                    randomDataEntries.Add(randomDataEntry);
                }
                return randomDataEntries;
            }
        }

        public RandomDataEntry ParseRandomDataLine(string line)
        {
            var splittedRandomData = line.Split("||");
            var dateValue = DateOnly.ParseExact(splittedRandomData[0], "dd.MM.yyyy");
            var enStingValue = splittedRandomData[1];
            var ruStringValue = splittedRandomData[2];
            var evenNumValue = long.Parse(splittedRandomData[3]);
            var decimalValue = decimal.Parse(splittedRandomData[4]);

            return new RandomDataEntry(dateValue, enStingValue, ruStringValue, evenNumValue, decimalValue);
        }
    }
}
