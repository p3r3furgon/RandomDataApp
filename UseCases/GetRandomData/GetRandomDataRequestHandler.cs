using B1Task1.Interfaces.Repositories;
using MediatR;

namespace B1Task1.UseCases.GetRandomData
{
    public class GetRandomDataRequestHandler
        : IRequestHandler<GetRandomDataRequest, GetRandomDataResponse>
    {
        private readonly IRandomDataRepository _randomDataRepository;

        public GetRandomDataRequestHandler(IRandomDataRepository randomDataRepository)
        {
            _randomDataRepository = randomDataRepository;
        }

        public async Task<GetRandomDataResponse> Handle(GetRandomDataRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var randomData = await _randomDataRepository.Get(request.Page, request.PageSize);
                return new GetRandomDataResponse(true, string.Empty, randomData);
            }
            catch(Exception ex)
            {
                return new GetRandomDataResponse(false, ex.Message, null);
            }
        }
    }
}
