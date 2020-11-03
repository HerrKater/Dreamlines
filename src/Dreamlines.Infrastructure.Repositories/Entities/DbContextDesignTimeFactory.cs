using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Dreamlines.Infrastructure.Repositories.Mapping
{
	public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<DreamlineDbContext>
	{
		public DreamlineDbContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.Build();
			var connectionString = configuration.GetConnectionString("DreamlinesConnectionString");
			var optionsBuilder = new DbContextOptionsBuilder<DreamlineDbContext>();
			optionsBuilder.UseSqlServer(connectionString);
			return new DreamlineDbContext(optionsBuilder.Options);
		}
	}
}
