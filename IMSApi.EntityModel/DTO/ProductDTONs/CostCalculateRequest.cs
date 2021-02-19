using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.DTO.ProductDTONs
{
    public class CostCalculateRequest
    {
        public int costprice { get; set; }
        public int prdStichingType { get; set; }

        public int CustomerShippingCost { get; set; }
        public int VendorShippingCost { get; set; }
        public int TraderMarginRupees { get; set; }
        
        public int CustomerMarginRupees { get; set; }
        
    }
}
