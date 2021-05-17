using System;
using System.Collections.Generic;
using System.Text;

namespace Guiado.Domain.BusinessAgregate
{
    public class BusinessProductFamily
    {
        public int Id { get; private set; }
        public int BusinessID { get; private set; }
        public int ProductFamilyID { get; private set; }

        public BusinessProductFamily(int id, int businessID, int productFamilyID)
        {
            this.Id = id;
            this.BusinessID = businessID;
            this.ProductFamilyID = productFamilyID;
        }
    }
}
