using Dreamlines.Domain.Exceptions;
using Dreamlines.Domain.InfrastructureInterfaces.Repositories;
using Dreamlines.Domain.Model;
using Dreamlines.Infrastructure.Repositories.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dreamlines.Infrastructure.Repositories
{
	public class BookingRepository : RepositoryBase, IBookingRepository
	{
		public BookingRepository(DreamlineDbContext dbContext) : base(dbContext)
		{
		}

		public IQueryable<Booking> ListBySalesUnitId(int salesUnitId)
		{
			if (dbContext.SalesUnits.Count(su => su.Id == salesUnitId) == 0)
				throw new EntityNotFoundException(typeof(SalesUnit), salesUnitId);

			var query = dbContext.Bookings
						.Include(su => su.Ship)
						.ThenInclude(ship => ship.SalesUnit)
						.Where(su => su.Ship.SalesUnitId == salesUnitId)
			 ;
			return query;
		}
	}
}
