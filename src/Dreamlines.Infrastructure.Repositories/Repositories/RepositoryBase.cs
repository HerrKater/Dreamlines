using Dreamlines.Infrastructure.Repositories.Mapping;

namespace Dreamlines.Infrastructure.Repositories
{
	public abstract class RepositoryBase
	{
		protected readonly DreamlineDbContext dbContext;
		public RepositoryBase(DreamlineDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
	}
}
