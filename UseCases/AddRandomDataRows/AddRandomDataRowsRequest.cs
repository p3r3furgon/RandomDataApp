using MediatR;

namespace B1Task1.UseCases.AddRandomDataRows
{
    public record AddRandomDataRowsRequest(List<string> RandomDataRows) 
        : IRequest<AddRandomDataRowsResponse>;
    public record AddRandomDataRowsResponse(bool IsSuccess, string Message);
}
