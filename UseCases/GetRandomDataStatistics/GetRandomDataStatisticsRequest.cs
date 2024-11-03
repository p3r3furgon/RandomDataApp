using MediatR;

namespace B1Task1.UseCases.GetRandomDataStatistics
{
    public record GetRandomDataStatisticsRequest: IRequest<GetRandomDataStatisticsResponse>;
    public record GetRandomDataStatisticsResponse(bool IsSuccess, string Message, long Sum, decimal Median);

}
