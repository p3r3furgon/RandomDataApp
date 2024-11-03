using B1Task1.Interfaces.Repositories;
using B1Task1.Interfaces.Services;
using B1Task1.Models;
using MediatR;

namespace B1Task1.UseCases.AddRandomDataRows
{
    public class AddRandomDataRowsRequestHandler
        : IRequestHandler<AddRandomDataRowsRequest, AddRandomDataRowsResponse>
    {
        private readonly IRandomDataParsingService _randomDataParsingService;
        private readonly IRandomDataRepository _randomDataRepository;

        public AddRandomDataRowsRequestHandler(IRandomDataParsingService randomDataParsingService, IRandomDataRepository randomDataRepository)
        {
            _randomDataParsingService = randomDataParsingService;
            _randomDataRepository = randomDataRepository;
        }
        public async Task<AddRandomDataRowsResponse> Handle(AddRandomDataRowsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var randomDataEntities = new List<RandomDataEntry>();
                foreach(var randomDataRow in request.RandomDataRows)
                    randomDataEntities.Add(_randomDataParsingService.ParseRandomDataLine(randomDataRow));
                await _randomDataRepository.AddRange(randomDataEntities);
                return new AddRandomDataRowsResponse(true, string.Empty);
            }
            catch(Exception ex)
            {
                return new AddRandomDataRowsResponse(false, ex.Message);
            }
        }
    }
}
