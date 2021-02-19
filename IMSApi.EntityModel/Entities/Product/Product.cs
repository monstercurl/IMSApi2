using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSApi.EntityModel.Entities.Product
{
    public class Product
    {
        
       [Key] public long Product_ID { get; set; }
        public Categories Category { get; set; }
        public ProductFabric Fabric { get; set; }
        public ProductStichingType StichingType { get; set; }
        public ICollection<ProductDesign> productDesign { get; set; }
        
        public string Description { get; set; }
        //public ICollection<Product_Design_Images> Image_Urls { get; set; }
       public ICollection<ProductImages> product_images { get; set; }

        


        public Vendor Vendor { get; set; }


        [Column(TypeName = "date")] public DateTime AddDate { get; set;}
        [DataType(DataType.Time)] public TimeSpan AddTime { get; set; }
        [Column(TypeName = "date")] public DateTime? UpdateDate { get; set;}
        [DataType(DataType.Time)] public TimeSpan? UpdateTime { get; set; }

        public string ProductImageDir { get; set; }
        public bool IsActive { get; set; }

        public int Cost_Price { get; set; }
        public int CustomerShippingCost{ get; set; }
        public int VendorShippingCost { get; set; }
        public int TraderMarginRupees { get; set; }
        public int TraderPrice { get; set; }
        public int CustomerMarginRupees { get; set; }
        public int CustomerPrice { get; set; }
    }

}
