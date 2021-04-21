using Guiado.Domain.UserAgregate;

namespace Guiado.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(GuiadoContext context) : base(context)
        { }
    }
}
