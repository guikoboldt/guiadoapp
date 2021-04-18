using Guiado.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Guiado.Domain.BusinessAgregate
{
    public class Business : Entity, IRootAgregate
    {
        public int Owner { get; private set; }
        private List<ProductFamily> _productsFamily;
        public IReadOnlyList<ProductFamily> ProductsFamily => this._productsFamily;
        private List<Product> _products;
        public IReadOnlyList<Product> Products => this._products;
        public int CoverArea { get; private set; }
        public int StartBusinessHour { get; private set; }
        public int EndBusinessHour { get; private set; }
        public int AvailableDays { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; protected set; }

        public Business(int id, string name, string email, int owner, int coverArea, int startBusinessHour, int endBusinessHour, int availableDays, string phone) : base(id, name)
        {
            this.Email = email;
            this.Owner = owner;
            this.CoverArea = coverArea;
            this.StartBusinessHour = startBusinessHour;
            this.EndBusinessHour = endBusinessHour;
            this.AvailableDays = availableDays;
            this.Phone = phone;
            this._productsFamily = new List<ProductFamily>();
            this._products = new List<Product>();
        }

        public void AddProductFamily(int id, string name, string description)
        {
            if (!this._productsFamily.Any(o => o.ID == id || string.Equals(o.Name, name)))
            {
                this._productsFamily.Add(new ProductFamily(id, name, description));
            }
        }

        public void AddProduct(int id, string name, string description, double price, int productFamilyID, int quantity)
        {
            //check productfamily
            if (!this._productsFamily.Any(o => o.ID == productFamilyID))
            {
                throw new Exception("the product Family is not valid or the business does not provide this family of items");
            }

            //check product
            if(!this._products.Any(o => o.ID == id || string.Equals(o.Name, name)))
            {
                this._products.Add(new Product(id, name, description, price, productFamilyID, quantity));
            }
        }
    }
}
