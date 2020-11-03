using Dreamlines.Domain.Exceptions;
using Dreamlines.Domain.InfrastructureInterfaces.Repositories;
using Dreamlines.Domain.Model;
using Dreamlines.Infrastructure.Repositories.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Dreamlines.Infrastructure.Repositories.Repositories
{

	public class SalesUnitRepository : RepositoryBase, ISalesUnitRepository
    {
		public SalesUnitRepository(DreamlineDbContext dbContext) : base(dbContext)
		{
		}

        public IQueryable<SalesUnit> List(string searchTerm, int offset, int limit)
        {
            var query = dbContext
                .SalesUnits
                .Include(su => su.Ships)
                .ThenInclude(ship => ship.Bookings)
                .AsQueryable();
                ;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(su => 
                    su.Name.Contains(searchTerm)
                    || su.Ships.Any(ship => ship.Name.Contains(searchTerm)
                    || su.Ships.Any(ship => ship.Bookings.Any(booking => booking.Id.ToString()==searchTerm))
                ));
            }
            return query
               .Skip(offset)
               .Take(limit);
        }

        public async Task<SalesUnit> GetById(int salesUnitId, bool loadBookings = true)
        {
            var query = dbContext.SalesUnits.AsQueryable();
			if (loadBookings)
			{
                query = query
                    .Include(su => su.Ships)
                    .ThenInclude(ship => ship.Bookings);
            }
            var result = await query.FirstOrDefaultAsync(su => su.Id == salesUnitId);

            if (result == null)
                throw new EntityNotFoundException(typeof(SalesUnit), salesUnitId);

            return result;
        }
    }
}
