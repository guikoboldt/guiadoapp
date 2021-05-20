using Guiado.Domain.SeedWork;

namespace Guiado.Domain.BusinessAgregate
{
    public class Product : Entity
    {
        public string Description { get; private set; }
        public double Price { get; private set; }
        public int ProductFamilyId { get; private set; }
        public int Quantity { get; private set; }

        public int BusinessId { get; private set; }

        public Product(int id, string name, string description, double price, int productFamilyId, int quantity, int businessId) : base(id, name)
        {
            this.Description = description;
            this.Price = price;
            this.ProductFamilyId = productFamilyId;
            this.Quantity = quantity;
            this.BusinessId = businessId;
        }
    }
}
