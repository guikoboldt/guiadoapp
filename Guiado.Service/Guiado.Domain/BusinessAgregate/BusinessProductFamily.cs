using System;
using System.Collections.Generic;
using System.Text;

namespace Guiado.Domain.BusinessAgregate
{
    public class BusinessProductFamily
    {
        public int Id { get; private set; }
        public int BusinessId { get; private set; }
        public int ProductFamilyId { get; private set; }

        public BusinessProductFamily(int id, int businessId, int productFamilyId)
        {
            this.Id = id;
            this.BusinessId = businessId;
            this.ProductFamilyId = productFamilyId;
        }
    }
}
