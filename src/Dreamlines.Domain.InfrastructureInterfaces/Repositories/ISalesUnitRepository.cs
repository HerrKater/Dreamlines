using Dreamlines.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dreamlines.Domain.InfrastructureInterfaces.Repositories
{
	public interface ISalesUnitRepository
	{
		Task<SalesUnit> GetById(int salesUnitId, bool loadBookings);
		IQueryable<SalesUnit> List(string searchTerm, int offset, int limit);
	}
}