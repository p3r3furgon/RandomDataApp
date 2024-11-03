using B1Task1.Interfaces.Services;
using MediatR;

namespace B1Task1.UseCases.GenerateRandomDataFiles
{
    public class GenerateRandomDataFilesRequestHandler :
        IRequestHandler<GenerateRandomDataFilesRequest, GenerateRandomDataFilesResponse>
    {
        private readonly IRandomDataFilesGenerationService _randomDataFilesGenerationService;

        public GenerateRandomDataFilesRequestHandler(IRandomDataFilesGenerationService randomDataFilesGenerationService)
        {
            _randomDataFilesGenerationService = randomDataFilesGenerationService;
        }

        public async Task<GenerateRandomDataFilesResponse> Handle(GenerateRandomDataFilesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _randomDataFilesGenerationService.GenerateFiles(request.FileNumber, request.LineNumber);
                return new GenerateRandomDataFilesResponse(true, string.Empty);
            }
            catch(Exception ex)
            {
                return new GenerateRandomDataFilesResponse(false, ex.Message);
            }
        }
    }
}
