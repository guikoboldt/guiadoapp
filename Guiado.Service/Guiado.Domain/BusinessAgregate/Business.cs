using Guiado.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Guiado.Domain.BusinessAgregate
{
    public class Business : Entity, IRootAgregate
    {
        public int Owner { get; private set; }
        private List<BusinessProductFamily> _productFamilies;
        public IReadOnlyList<BusinessProductFamily> ProductFamilies => this._productFamilies;
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
            this._productFamilies = new List<BusinessProductFamily>();
            this._products = new List<Product>();
        }

        public void AddProductFamily(int id, int productFamilyID)
        {
            if (!this._productFamilies.Any(o => o.ID == id ))
            {
                this._productFamilies.Add(new BusinessProductFamily(id, this.ID, productFamilyID));
            }
        }

        public void AddProduct(int id, string name, string description, double price, int productFamilyID, int quantity)
        {
            //check productfamily
            if (!this._productFamilies.Any(o => o.ID == productFamilyID))
            {
                throw new Exception("the product Family is not valid or the business does not provide this family of items");
            }

            //check product
            if(!this._products.Any(o => o.ID == id || string.Equals(o.Name, name)))
            {
                this._products.Add(new Product(id, name, description, price, productFamilyID, quantity, this.ID));
            }
        }
    }
}
