using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Reports.Api.Context;
using Reports.Api.Dtos;
using Reports.Api.Entity;
using Reports.Api.Services.Abstract;

namespace Reports.Api.Services.Concrete
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _dbContext;
        private readonly RabbitMQService _rabbitMQService;
        public ReportService(AppDbContext dbContext, RabbitMQService rabbitMQService)
        {
            _dbContext = dbContext;
            _rabbitMQService = rabbitMQService;
        }

        public async Task<Guid> RequestReportAsync(ReportRequestDto requestDto)
        {
            var report = new Report
            {
                ID = Guid.NewGuid(),
                RequestedDate = DateTime.UtcNow,
                ReportStatus = "Hazırlanıyor",
                Location = requestDto.Location,
            };

            _dbContext.Reports.Add(report);
            await _dbContext.SaveChangesAsync();

            _rabbitMQService.SendMessage(JsonConvert.SerializeObject(report));

            return report.ID;
        }

        public async Task<List<ReportStatusDto>> GetReporStatus()
        {
            var reportStatus = await _dbContext.Reports
                 .Select(r => new ReportStatusDto
                 {
                     Id = r.ID,
                     RequestAt = r.RequestedDate,
                     Location = r.Location,
                     Status = r.ReportStatus
                 })
                 .ToListAsync();

            return reportStatus;
        }
    }
}