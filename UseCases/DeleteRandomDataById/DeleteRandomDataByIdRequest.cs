using MediatR;

namespace B1Task1.UseCases.DeleteRandomDataById
{
    public record DeleteRandomDataByIdRequest(int Id) 
        : IRequest<DeleteRandomDataByIdResponse>;
    public record DeleteRandomDataByIdResponse(bool IsSuccess, string Message);
}
