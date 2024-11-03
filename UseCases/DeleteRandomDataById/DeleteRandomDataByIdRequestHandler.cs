using B1Task1.Interfaces.Repositories;
using MediatR;

namespace B1Task1.UseCases.DeleteRandomDataById
{
    public class DeleteRandomDataByIdRequestHandler
        : IRequestHandler<DeleteRandomDataByIdRequest, DeleteRandomDataByIdResponse>
    {
        private readonly IRandomDataRepository _randomDataRepository;

        public DeleteRandomDataByIdRequestHandler(IRandomDataRepository randomDataRepository)
        {
            _randomDataRepository = randomDataRepository;
        }

        public async Task<DeleteRandomDataByIdResponse> Handle(DeleteRandomDataByIdRequest request, CancellationToken cancellationToken)
        {

            var dataEntry = await _randomDataRepository.GetById(request.Id);

            if(dataEntry == null)
                return new DeleteRandomDataByIdResponse(false, "Data is not found");

            await _randomDataRepository.Delete(request.Id);
            return new DeleteRandomDataByIdResponse(true, string.Empty);
        }
    }
}
