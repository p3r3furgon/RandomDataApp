using MediatR;

namespace B1Task1.UseCases.DeleteAllRandomData
{
    public record DeleteAllRandomDataRequest() : IRequest<DeleteAllRandomDataResponse>;
    public record DeleteAllRandomDataResponse(bool IsSuccess, string Message);
}
