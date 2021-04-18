using System.Threading.Tasks;

namespace Guiado.Domain.BusinessAgregate
{
    public interface IBusinessRepository
    {
        Business Add(Business buyer);
        Business Update(Business buyer);
        Task<Business> Get(int businessID);
    }
}
