using Dreamlines.Domain.InfrastructureInterfaces.Repositories;
using Dreamlines.Domain.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Dreamlines.ApplicationServices
{
	public class SalesUnitService : ISalesUnitService
	{
		private readonly ISalesUnitRepository salesUnitRepo;
		private readonly IBookingRepository bookingRepo;

		public SalesUnitService(ISalesUnitRepository salesUnitRepo,IBookingRepository bookingRepo)
		{
			this.salesUnitRepo = salesUnitRepo;
			this.bookingRepo = bookingRepo;
		}
		public async Task<SalesUnit> GetById(int salesUnitId)
		{
			return await salesUnitRepo.GetById(salesUnitId,true);
		}
		public IQueryable<SalesUnit> List(string searchTerm, int offset, int limit)
		{
			return salesUnitRepo.List(searchTerm,offset,limit);
		}

		
	}
}
