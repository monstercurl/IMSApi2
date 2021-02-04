using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IMSApi.EntityModel.Entities.Product
{
    public class Product
    {
        
       [Key] public long Product_ID { get; set; }
        public Categories Category { get; set; }
        public ICollection<ProductDesign> productDesign { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProductImages> Image_Urls { get; set; }

        public int Cost_Price { get; set; }

        public int Selling_price { get; set; }
        public Vendor Vendor { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
       
    }
}
