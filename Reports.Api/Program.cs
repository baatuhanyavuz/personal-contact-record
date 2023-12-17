using Microsoft.EntityFrameworkCore;
using Reports.Api.Context;
using Reports.Api.Services.Abstract;
using Reports.Api.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<RabbitMQService>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();
