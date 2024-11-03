using MediatR;

namespace B1Task1.UseCases.AddRandomDataFromFile
{
    public record AddRandomDataFromFileRequest(IFormFile File) 
        : IRequest<AddRandomDataFromFileResponse>;
    public record AddRandomDataFromFileResponse(bool IsSuccess, string Message);
}
