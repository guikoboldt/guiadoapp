using Guiado.Domain.SeedWork;

namespace Guiado.Domain.BusinessAgregate
{
    public class ProductFamily : Entity
    {
        public string Description { get; private set; }

        public ProductFamily(int id, string name, string description) : base(id, name)
        {
            this.Description = description;
        }
    }
}
