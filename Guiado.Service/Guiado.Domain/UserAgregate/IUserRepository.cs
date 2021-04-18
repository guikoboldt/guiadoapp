using System.Threading.Tasks;

namespace Guiado.Domain.UserAgregate
{
    public interface IUserRepository
    {
        User Add(User user);

        void Update(User user);

        Task<User> Get(int userID);
    }
}
