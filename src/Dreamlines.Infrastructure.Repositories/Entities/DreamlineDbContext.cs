using Dreamlines.Domain.Model;
using Dreamlines.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dreamlines.Infrastructure.Repositories.Mapping
{
	public class DreamlineDbContext : DbContext
	{
		public DreamlineDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Booking>()
				.HasOne(p => p.Ship)
				.WithMany(b => b.Bookings)
				.HasForeignKey(p => p.ShipId)
				;

			modelBuilder.Entity<Ship>()
				.HasOne(p => p.SalesUnit)
				.WithMany(b => b.Ships)
				.HasForeignKey(p => p.SalesUnitId)
				;
		}

		public bool IsDatabaseEmpty()
		{
			return
				SalesUnits.Count() == 0
				&& Ships.Count() == 0
				&& Bookings.Count() == 0
				;
		}

		public void ImportData(ImportStructure importStructure)
		{
			importStructure.RestoreReferences();
			importStructure.CleanupIds();

			foreach(var salesUnit in importStructure.salesUnits)
			{
				SalesUnits.Add(salesUnit);
			}
			SaveChanges();
		}

		#region Domain entities
		public DbSet<SalesUnit> SalesUnits { get; set; }
		public DbSet<Ship> Ships { get; set; }
		public DbSet<Booking> Bookings { get; set; }

		#endregion

		#region Infrastructure

		public DbSet<Log> Log { get; set; }

		#endregion
	}
}
