using B1Task1.Interfaces.Repositories;
using MediatR;

namespace B1Task1.UseCases.DeleteAllRandomData
{
    public class DeleteAllRandomDataRequestHandler
        : IRequestHandler<DeleteAllRandomDataRequest, DeleteAllRandomDataResponse>
    {
        private readonly IRandomDataRepository _randomDataRepository;

        public DeleteAllRandomDataRequestHandler(IRandomDataRepository randomDataRepository)
        {
            _randomDataRepository = randomDataRepository;
        }

        public async Task<DeleteAllRandomDataResponse> Handle(DeleteAllRandomDataRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _randomDataRepository.DeleteAll();
                return new DeleteAllRandomDataResponse(true, string.Empty);
            }
            catch(Exception ex)
            {
                return new DeleteAllRandomDataResponse(false, ex.Message);
            }
        }
    }
}
