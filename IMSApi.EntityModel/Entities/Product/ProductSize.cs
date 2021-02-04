using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.Entities.Product
{
   public  class ProductSize
    {
        
         [Key]   public int Id { get; set; }
            public string Value { get; set; }
        

    }
}
