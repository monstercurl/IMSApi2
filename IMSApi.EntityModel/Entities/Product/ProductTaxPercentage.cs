using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.Entities.Product
{
   public class ProductTaxPercentage
    {
        public int Id { get; set; }

        [ForeignKey("ProductStichingType")]
        public int productstichingtypeId { get; set; }
        public ProductStichingType productstichingtype { get; set; }
        public string taxtype { get; set; }
        public int taxpercentage { get; set; }
    }
}
