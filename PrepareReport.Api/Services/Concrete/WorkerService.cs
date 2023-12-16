using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PrepareReport.Api.Context;
using PrepareReport.Api.Entity;
using PrepareReport.Api.Services.Abstract;

public class WorkerService : IWorkerService
{
    private readonly AppDbContext _appDbContext;
    private readonly RabbitMQService _rabbitMQService;

    public WorkerService(AppDbContext appDbContext, RabbitMQService rabbitMQService)
    {
        _appDbContext = appDbContext;
        _rabbitMQService = rabbitMQService;
    }

    public async Task PrepareReport()
    {
        _rabbitMQService.StartConsuming(async message =>
        {
            Console.WriteLine($"Queue Message: {message}");

            var qMessage = JsonConvert.DeserializeObject<Report>(message);

            var existingReport = await _appDbContext.Reports.FindAsync(qMessage.ID);

            if (existingReport != null)
            {
                var getReportRequest = _appDbContext.Reports.FindAsync(existingReport.ID);
                var getLocationFilter = _appDbContext.Persons
                .Include(p => p.ContactInformation)
                .Where(p => p.ContactInformation.FirstOrDefault().Location == getReportRequest.Result.Location)
                .ToListAsync();

                int registiredPhone = 0;
                foreach (var item in getLocationFilter.Result)
                {
                    if (item.ContactInformation.FirstOrDefault().Phone != "")
                        registiredPhone++;

                    var reportDetail = new ReportDetail()
                    {
                        ReportId = existingReport.ID,
                        PersonId = item.ID
                    };
                     _appDbContext.ReportDetails.Add(reportDetail);
                }

                existingReport.ReportStatus = "Tamamlandı";
                existingReport.RegisteredPersonCount = getLocationFilter.Result.Count();
                existingReport.RegisteredPhoneNumberCount = registiredPhone;
                _appDbContext.Update(existingReport);
                await _appDbContext.SaveChangesAsync();
            }
        });
    }
}
