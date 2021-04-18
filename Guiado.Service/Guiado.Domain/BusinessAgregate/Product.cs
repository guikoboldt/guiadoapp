using Guiado.Domain.SeedWork;

namespace Guiado.Domain.BusinessAgregate
{
    public class Product : Entity
    {
        public string Description { get; private set; }
        public double Price { get; private set; }
        public int ProductFamilyID { get; private set; }
        public int Quantity { get; private set; }

        public Product(int id, string name, string description, double price, int familyProductID, int quantity) : base(id, name)
        {
            this.Description = description;
            this.Price = price;
            this.ProductFamilyID = familyProductID;
            this.Quantity = quantity;
        }
    }
}
