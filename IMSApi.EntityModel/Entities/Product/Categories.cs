using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.Entities.Product
{
    public class Categories
    {
        public int Id { get; set; }
        public string Category_Value { get; set; }
        public int Parent_Category { get; set; }
    }
}
