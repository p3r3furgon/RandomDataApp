using B1Task1.Interfaces.Services;
using MediatR;

namespace B1Task1.UseCases.CombineRandomDataFiles
{
    public class CombineRandomDataFilesRequestHander
        : IRequestHandler<CombineRandomDataFilesRequest, CombineRandomDataFilesResponse>
    {
        private readonly IRandomDataFilesGenerationService _randomDataFilesGenerationService;

        public CombineRandomDataFilesRequestHander(IRandomDataFilesGenerationService randomDataFilesGenerationService)
        {
            _randomDataFilesGenerationService = randomDataFilesGenerationService;
        }
        public async Task<CombineRandomDataFilesResponse> Handle(CombineRandomDataFilesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var deletedRowsNumber = await _randomDataFilesGenerationService.CombineFiles(request.File1, request.File2, 
                    request.OutputFileName, request.Filter);
                return new CombineRandomDataFilesResponse(true, deletedRowsNumber, string.Empty);
            }
            catch (Exception ex)
            {
                return new CombineRandomDataFilesResponse(false, 0, ex.Message);
            }
        }
    }
}
