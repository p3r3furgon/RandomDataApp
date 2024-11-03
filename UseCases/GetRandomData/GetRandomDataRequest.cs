using B1Task1.Models;
using MediatR;

namespace B1Task1.UseCases.GetRandomData
{
    public record GetRandomDataRequest(int Page, int PageSize) : IRequest<GetRandomDataResponse>;
    public record GetRandomDataResponse(bool IsSuccess, string Message, List<RandomDataEntry> RandomData);
}
