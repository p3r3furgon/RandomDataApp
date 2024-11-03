using B1Task1.Interfaces.Repositories;
using B1Task1.Interfaces.Services;
using MediatR;

namespace B1Task1.UseCases.AddRandomDataFromFile
{
    public class AddRandomDataFromFileRequestHandler
        : IRequestHandler<AddRandomDataFromFileRequest, AddRandomDataFromFileResponse>
    {
        private readonly IRandomDataParsingService _randomDataParsingService;
        private readonly IRandomDataRepository _randomDataRepository;

        public AddRandomDataFromFileRequestHandler(IRandomDataParsingService randomDataParsingService, IRandomDataRepository randomDataRepository)
        {
            _randomDataParsingService = randomDataParsingService;
            _randomDataRepository = randomDataRepository;
        }
        public async Task<AddRandomDataFromFileResponse> Handle(AddRandomDataFromFileRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _randomDataParsingService.Parse(request.File);
                await _randomDataRepository.AddRange(data);
                return new AddRandomDataFromFileResponse(true, string.Empty);
            }
            catch(Exception ex)
            {
                return new AddRandomDataFromFileResponse(false, ex.Message);
            }            
        }
    }
}
