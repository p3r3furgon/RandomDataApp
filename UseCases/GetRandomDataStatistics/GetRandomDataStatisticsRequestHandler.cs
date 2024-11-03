using B1Task1.Interfaces.Repositories;
using B1Task1.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace B1Task1.UseCases.GetRandomDataStatistics
{
    public class GetRandomDataStatisticsRequestHandler
        : IRequestHandler<GetRandomDataStatisticsRequest, GetRandomDataStatisticsResponse>
    {
        private readonly IRandomDataRepository _randomDataRepository;

        public GetRandomDataStatisticsRequestHandler(IRandomDataRepository randomDataRepository)
        {
            _randomDataRepository = randomDataRepository;
        }
        public async Task<GetRandomDataStatisticsResponse> Handle(GetRandomDataStatisticsRequest request, CancellationToken cancellationToken)
        {
            try 
            {
                var randomData = await _randomDataRepository.Get();
                var sum = randomData.Sum(e => e.EvenNumber);
                var median = GetMedian(randomData);

                return new GetRandomDataStatisticsResponse(true, string.Empty, sum, median);
            }
            catch(Exception ex)
            {
                return new GetRandomDataStatisticsResponse(false, ex.Message, default(int), default(decimal));
            }
        }

        public decimal GetMedian(List<RandomDataEntry> randomData)
        {
            var decimalValues = randomData
                .Select(e => e.DecimalNumber)
                .OrderBy(v => v)
                .ToList();

            if (decimalValues.Count == 0)
                throw new Exception("");

            int count = decimalValues.Count;

            if (count % 2 == 0) 
                return (decimalValues[count / 2 - 1] + decimalValues[count / 2]) / 2;
            else
                return decimalValues[count / 2];
        }
    }
}
