using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.Entities.Product
{
   public  class ProductDesign
    {
     [Key]   public long Id { get; set; }

        public ProductColor productColor { get; set; }
        public ProductSize productSize { get; set; }

        public Product product { get; set; }
        public int Quantity { get; set; }
    }

}
