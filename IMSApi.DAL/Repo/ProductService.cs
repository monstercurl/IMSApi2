using IMSApi.DAL.Common;
using IMSApi.EntityModel.DTO.ProductDTONs;
using IMSApi.EntityModel.Entities.Product;
using IMSApi.EntityModel.IRepo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.DAL.Repo
{
    public class ProductService : IProductService
    {
        IMSApiDbContext _context;
        private readonly AppSettings _appSettings;
        public ProductService(IMSApiDbContext context, IOptions<AppSettings> appSettings) 
        {

            _context = context;
            _appSettings = appSettings.Value;

        }

        public string AddCategory(CategoryDTO catDTO)
        {
            Categories cat = new Categories();
            cat.Category_Value = catDTO.Category_Value;
            cat.Parent_Category = catDTO.Parent_Category;
            _context.Categories.Add(cat);
            _context.SaveChanges();
            return "Category Added Succesfully";
        }

        public string AddColor(ProductColorDTO productColorDTO)
        {
            ProductColor col = new ProductColor();
            col.ProductColorValue = productColorDTO.ColorValue;
            
            _context.productColor.Add(col);
            _context.SaveChanges();

            return "Color Added Succesfully";
        }

        public string AddProduct(ProdcutRequest prdReq, IWebHostEnvironment webHostEnv,List<ProdcutDesignDTO> productDesignLists)
        {
            Product prd = new Product();
            prd.Name = prdReq.Name;
            prd.Category = _context.Categories.FirstOrDefault(x => x.Id == prdReq.Category_Id);
            List<ProductDesign> ListOfPrductDesign = new List<ProductDesign>();
            foreach( ProdcutDesignDTO productDesignDTO in productDesignLists)
             {
                ListOfPrductDesign.Add(
                    new ProductDesign()
                    {
                        product = prd,
                        productColor = _context.productColor.FirstOrDefault(x => x.ProductColor_ID == productDesignDTO.colorID),
                        productSize = _context.productSize.FirstOrDefault(x => x.Id == productDesignDTO.SizeID),
                        Quantity = productDesignDTO.Qty

                    }
                    );
            }
            prd.productDesign = ListOfPrductDesign;
            List<ProductImages> ImageUrls = new List<ProductImages>();
            string folderforImage = "prd_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
            foreach (string _imgUrl in UploadImage(prdReq.Image, webHostEnv,folderforImage))
            {
                ImageUrls.Add(new ProductImages() { Physicalurl = _imgUrl,product=prd,folderName = folderforImage });
            }
            prd.Image_Urls = ImageUrls;
            prd.Description = prdReq.Description;
            prd.Cost_Price = prdReq.Cost_Price;
            prd.Selling_price = prdReq.Selling_price;
            prd.Vendor = _context.Vendor.FirstOrDefault(x => x.Id == prdReq.VendorId);
            prd.AddDate = DateTime.UtcNow;
            prd.UpdateDate = null;

            _context.product.Add(prd);
            _context.SaveChanges();

            return "Added Successfully";

        }

        public string AddSize(ProductSizeDTO productSizeDTO)
        {
            ProductSize size = new ProductSize();
            size.Value = productSizeDTO.Value;

            _context.productSize.Add(size);
            _context.SaveChanges();
            return "Color Added Succesfully";
        }

        public string DeleteProduct(long ProductId)
        {//Can Not be deleted
            //Product product = null;
            //using (_context)
            //{
               
            //    product = _context.product.Where(e => e.Product_ID == ProductId).Include(e => e.productDesign)
            //        .Include(e => e.Image_Urls).First();
            //    foreach (ProductImages pri in product.Image_Urls)
            //    {
            //        product.Image_Urls.Remove(pri);
            //    }
            //    foreach (ProductDesign pri in product.productDesign)
            //    {
            //        product.productDesign.Remove(pri);
            //    }
            //    _context.product.Remove(product);
            //    _context.SaveChanges();
            //}
          
        
            return "Can Not  delete Sorry";
        }

      

        public AddProductReponse ExistingData()
        {
             AddProductReponse addProductResponse = new AddProductReponse();
            var catList = _context.Categories.ToList();
            var colList = _context.productColor.ToList();
            var sizeList = _context.productSize.ToList();

            addProductResponse.ListOfCategories = catList;
            addProductResponse.ProductColor = colList;
            addProductResponse.ProductSizes = sizeList;

            return addProductResponse;

        }

        public List<ProductResponse> GeAllProducts(HttpRequest req)
        {
            var listOfProducts = _context.product.ToList();
            using (_context)
            {
                 _context.product.Include(acc => acc.Category).ToList();
                _context.product.Include(acc => acc.productDesign).ToList();
                _context.product.Include(acc => acc.Image_Urls).ToList();

            }
            List<ProductResponse> ListOfProductResponse = new List<ProductResponse>();
           foreach (Product prd in listOfProducts)
            {
                ListOfProductResponse.Add(new ProductResponse(prd,req));
            }

            
            return ListOfProductResponse;

        }

        public List<ProductDesign> GetDesignsForGivenProduct(int Id)
        {
           var listOfDesign = (from s in _context.productDesign
                              where s.product.Product_ID == Id
                              select s).ToList();

            return listOfDesign;
        }

        public string UpdateProduct(ProdcutRequest prdReq)
        {
            throw new NotImplementedException();
        }

        public List<string> UploadImage(List<IFormFile> Img, IWebHostEnvironment webHostEnvironment,string prdUniqueFolderName)
        {
            string uniqueFileName ;
            string filePath ;
            List<string> ImageUrl = new List<string>();
            if ( Img!= null)
            {
                string uploadsFolder;
                if (_appSettings.PhysicalStoragePath == String.Empty)
                {
                    uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                }
                else
                {
                    uploadsFolder = Path.Combine(_appSettings.PhysicalStoragePath, "images");
                }
                string productSpecifiPath = Path.Combine(uploadsFolder, prdUniqueFolderName);
                if (!Directory.Exists(productSpecifiPath))
                {
                    Directory.CreateDirectory(productSpecifiPath);
                }
                

                foreach (IFormFile img in Img)
                {
                    uniqueFileName = Guid.NewGuid().ToString();
                    filePath = Path.Combine(productSpecifiPath, uniqueFileName+Path.GetExtension(img.FileName));
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        img.CopyTo(fileStream);
                        ImageUrl.Add(filePath);

                    } 
                }
            }
            return ImageUrl;
        }
    }
}
