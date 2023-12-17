using Reports.Api.Dtos;

namespace Reports.Api.Services.Abstract
{
    public interface IReportService
    {
        Task<Guid> RequestReportAsync(ReportRequestDto requestDto);
        Task<List<ReportDto>> GetReport();
        Task<List<ReportStatusDto>> GetReporStatus();
    }
}
