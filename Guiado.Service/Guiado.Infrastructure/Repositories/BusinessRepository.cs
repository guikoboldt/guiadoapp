using Guiado.Domain.BusinessAgregate;

namespace Guiado.Infrastructure.Repositories
{
    public class BusinessRepository : RepositoryBase<Business>, IBusinessRepository
    {
        public BusinessRepository(GuiadoContext context) : base(context)
        { }
    }
}
