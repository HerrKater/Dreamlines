using Dreamlines.Domain.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Dreamlines.ApplicationServices
{
	public interface ISalesUnitService
	{
		Task<SalesUnit> GetById(int salesUnitId);
		IQueryable<SalesUnit> List(string searchTerm,int offset,int limit);
		
	}
}