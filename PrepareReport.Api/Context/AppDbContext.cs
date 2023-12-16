using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PrepareReport.Api.Entity;

namespace PrepareReport.Api.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseNpgsql(connectionString);

            return new AppDbContext(builder.Options);
        }
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportDetail> ReportDetails { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }

    }
}
