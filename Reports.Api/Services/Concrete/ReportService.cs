using Microsoft.EntityFrameworkCore;
using Reports.Api.Context;
using Reports.Api.Dtos;
using Reports.Api.Entity;
using Reports.Api.Services.Abstract;

namespace Reports.Api.Services.Concrete
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _dbContext;
      
        public ReportService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        
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