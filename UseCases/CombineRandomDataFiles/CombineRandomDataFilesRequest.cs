using MediatR;

namespace B1Task1.UseCases.CombineRandomDataFiles
{
    public record CombineRandomDataFilesRequest(IFormFile File1, IFormFile File2, string OutputFileName, string Filter)
        : IRequest<CombineRandomDataFilesResponse>;
    public record CombineRandomDataFilesResponse(bool IsSuccess, int RemovedLinesNumber, string Message);
}
