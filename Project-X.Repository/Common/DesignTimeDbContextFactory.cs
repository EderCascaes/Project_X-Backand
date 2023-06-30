using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace Project_X.Repository.Common
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var fileName = Directory.GetCurrentDirectory() + $"/../Project-X.WebAPI/appsettings.{environmentName}.json";

            var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();
            var connectionString = configuration.GetConnectionString("App");

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseNpgsql(connectionString);

            /*var logConsole = new LoggerFactory();
            builder.UseLoggerFactory(logConsole);*/

            return new ApplicationDbContext(builder.Options);
        }
    }
}
