using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.Entities.Product
{
    public class Product_Design_Images
    {
        public long Id { get; set; }

        [ForeignKey("ProductImages")]
        public int ProductImagesId{get;set;}
        public ProductImages ProductImage {get;set;}






}
}
