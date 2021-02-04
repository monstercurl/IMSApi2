using IMSApi.EntityModel.DTO.ProductDTONs;
using IMSApi.EntityModel.Entities.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.IRepo
{
    public interface IProductService
    {
        public string AddProduct(ProdcutRequest prdReq, IWebHostEnvironment webHostingEnv,List<ProdcutDesignDTO> designDto);
        public AddProductReponse ExistingData();
        public List<ProductResponse> GeAllProducts(HttpRequest req);
        public string DeleteProduct(long ProductId);

       
        public string AddCategory(CategoryDTO catDTO);
        public string AddColor(ProductColorDTO productColorDTO);
        public string AddSize(ProductSizeDTO productSizeDTO);
        
        public List<ProductDesign> GetDesignsForGivenProduct(int Id);
        public List<string> UploadImage(List<IFormFile> Img, IWebHostEnvironment web,string prdImage);
        public string UpdateProduct(ProdcutRequest prdReq);







    }
}
