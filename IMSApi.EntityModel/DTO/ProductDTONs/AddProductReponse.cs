using IMSApi.EntityModel.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.DTO.ProductDTONs
{
    public class AddProductReponse
    {

        public IEnumerable<ProductColor> ProductColor { get; set; }
        public IEnumerable<Categories> ListOfCategories { get; set; }
        public IEnumerable<ProductSize> ProductSizes { get; set; }
        public IEnumerable<ProductFabric> ProdctFabrics { get; set; }
        public IEnumerable<ProductStichingType> ProductStichingTypes { get; set; }
        


    }
    public class ProductColorDTO
    {
       
        public string ColorValue { get; set; }

    }
    public class CategoryDTO
    {
       
        public string Category_Value { get; set; }
        public int Parent_Category { get; set; }

    }
    public class ProductSizeDTO
    {
        
        public string Value { get; set; }

    }
    public class ProductFebricDTO
    {

        public string Value { get; set; }

    }
    public class ProductStiching
    {

        public string Value { get; set; }

    }

}
