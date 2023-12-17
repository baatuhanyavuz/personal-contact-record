using Microsoft.AspNetCore.Mvc;
using Reports.Api.Dtos;
using Reports.Api.Services.Abstract;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;
    public ReportController(IReportService reportService)
    {

        _reportService = reportService;
    }

    [HttpPost("ReportRequest")]
    public async Task<ActionResult> ReportRequest(ReportRequestDto data)
    {
        await _reportService.RequestReportAsync(data);
        return Ok();
    }

    [HttpGet("GetReportStatus")]
    public async Task<ActionResult> GetReportStatus()
    {
        var result = await _reportService.GetReporStatus();
        return Ok(result);
    }

    [HttpGet("GetReports")]
    public async Task<ActionResult> GetReports()
    {
        var result = await _reportService.GetReport();
        return Ok(result);
    }

}
