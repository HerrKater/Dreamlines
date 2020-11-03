using Dreamlines.Domain.InfrastructureInterfaces.Repositories;
using Dreamlines.Domain.Model;
using System.Linq;

namespace Dreamlines.ApplicationServices
{
	public class BookingService : IBookingService
	{
		private readonly IBookingRepository bookingRepo;

		public BookingService(IBookingRepository bookingRepo)
		{
			this.bookingRepo = bookingRepo;
		}
		public IQueryable<Booking> ListBySalesUnitId(int salesUnitId)
		{
			return bookingRepo.ListBySalesUnitId(salesUnitId);
		}
	}
}