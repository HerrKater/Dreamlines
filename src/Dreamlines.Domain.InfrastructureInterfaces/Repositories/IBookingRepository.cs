using Dreamlines.Domain.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Dreamlines.Domain.InfrastructureInterfaces.Repositories
{
	public interface IBookingRepository
	{
		IQueryable<Booking> ListBySalesUnitId(int salesUnitId);
	}
}