using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.Entities.Product
{
   public class ProductColor
    {
      [Key]  public int ProductColor_ID { get; set; }

        public string ProductColorValue { get; set; }
        
    }
}
