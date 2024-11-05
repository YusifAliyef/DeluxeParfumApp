using DeluxeParfum.Persistance.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DeluxeParfum.WebApi.Data
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<DeluxeParfumContext>
    {
        public DeluxeParfumContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DeluxeParfumContext>();
            var connectionString = configuration.GetConnectionString("local");
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("DeluxeParfum.Persistance"));

            return new DeluxeParfumContext(builder.Options);
        }
    }
}
