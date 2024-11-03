using MediatR;

namespace B1Task1.UseCases.GenerateRandomDataFiles
{
    public record GenerateRandomDataFilesRequest(int FileNumber, int LineNumber) 
        : IRequest<GenerateRandomDataFilesResponse>;

    public record GenerateRandomDataFilesResponse(bool IsSuccess, string Message);
}
