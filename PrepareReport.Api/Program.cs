using Microsoft.EntityFrameworkCore;
using PrepareReport.Api.Context;
using PrepareReport.Api.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

builder.Services.AddScoped<RabbitMQService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())  
{
    var workerService = scope.ServiceProvider.GetRequiredService<IWorkerService>();

    while (true)
    {
        workerService.PrepareReport().Wait();
    }
}
