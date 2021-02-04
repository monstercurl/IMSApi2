using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.Entities.Product
{
   public class ProductImages
    {
        public int id { get; set; }

        public string folderName { get; set; }
       
        public string Physicalurl { get; set; }
        public Product product { get; set; }
    }
}
