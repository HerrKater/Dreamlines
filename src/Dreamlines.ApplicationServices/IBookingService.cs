using Dreamlines.Domain.Model;
using System.Linq;

namespace Dreamlines.ApplicationServices
{
	public interface IBookingService
	{
		IQueryable<Booking> ListBySalesUnitId(int salesUnitId);
	}
}