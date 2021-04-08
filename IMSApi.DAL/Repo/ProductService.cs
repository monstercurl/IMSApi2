using IMSApi.DAL.Common;
using IMSApi.EntityModel.DTO.Common;
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
using System.Drawing;
using System.Drawing.Imaging;
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
            cat.category_value = catDTO.Category_Value;

            _context.categories.Add(cat);
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
        public long AddProductHeader(ProdcutRequest prdReq)
        {
            Product prd = new Product();
            prd.Category = _context.categories.FirstOrDefault(x => x.id == prdReq.Category_Id);
            prd.Fabric = _context.productfabric.FirstOrDefault(x => x.Id == prdReq.Fabric_Id);
            prd.StichingType = _context.productstichingtype.FirstOrDefault(x => x.id == prdReq.StichingTypeId);
            prd.Description = prdReq.Description;
            prd.Cost_Price = prdReq.Cost_Price;
           
            prd.Vendor = _context.vendor.FirstOrDefault(x => x.Id == prdReq.VendorId);
            prd.AddDate = DateTime.UtcNow;
            prd.AddTime = DateTime.UtcNow.TimeOfDay;
            prd.UpdateTime = null;
            prd.UpdateDate = null;
            string folderForProductRelatedImages = "prd_" + DateTime.Now.ToString("yyyMMddHHmmss");
            prd.ProductImageDir = folderForProductRelatedImages;
            prd.IsActive = false;
            prd.TraderMarginRupees = prdReq.TraderMarginRupees;
            prd.VendorShippingCost = prdReq.VendorShippingCost;
            prd.TraderPrice = prdReq.TraderPrice;
            prd.CustomerShippingCost = prdReq.CustomerShippingCost;
            prd.CustomerMarginRupees = prdReq.CustomerMarginRupees;
            prd.CustomerPrice = prdReq.CustomerPrice;
            
            _context.product.Add(prd);
            _context.SaveChanges();

            return prd.Product_ID;
        }

        public string AddProductDesign
            (
            ProdcutDesignDTO PrdDesign,
            IWebHostEnvironment webHostEnv,
            List<ProductSizeAndQuantityJson> productquantityList
            )
        {

            using (_context)
            {
                String WaterMarkId = null;
                Product product = new Product();
                product = _context.product.Where(e => e.Product_ID == PrdDesign.ProductId).Include(e => e.productDesign).ThenInclude(e => e.product_design_images)
                         .Include(e => e.product_images).First();





                ICollection<ProductImages> productImages = new List<ProductImages>();

                foreach (string _imgUrl in UploadImage(PrdDesign.ImagesWithDesign, webHostEnv, product.ProductImageDir, WaterMarkId))
                {
                    ProductImages prdI = new ProductImages() { Physicalurl = _imgUrl, folderName = product.ProductImageDir };
                    productImages.Add(prdI);
                    product.product_images.Add(prdI);


                }




                ICollection<ProductDesign> prddee = new List<ProductDesign>();
                prddee = product.productDesign;
                foreach (ProductSizeAndQuantityJson psq in productquantityList)
                {
                   
                   ProductDesign prdes = new ProductDesign();
                   prdes.productColor = _context.productColor.FirstOrDefault(x => x.ProductColor_ID == PrdDesign.colorID);
                    prdes.productSize = _context.productSize.FirstOrDefault(x => x.Id == psq.SizeID);
                    prdes.Quantity = psq.Qty;
                    
                     prdes.product_design_images =( from pop in productImages select new Product_Design_Images() { ProductImage = pop }).ToList();
                   // prdes.product_design_images = (from pop in UploadImagegAndGetTheURLs(PrdDesign,webHostEnv,product, prdes.Id) select new Product_Design_Images() { ProductImage = pop }).ToList();

                    prddee.Add(prdes);


                }
                
                


                product.productDesign = prddee;

                _context.SaveChanges();

                foreach (ProductImages prdImg in productImages) {

                    AddWaterMarkToTheImages(prdImg.Physicalurl, prdImg.id.ToString(), PrdDesign.ImagesWithDesign.First());
                
                }
                // product.product_design_images = ImageUrlsDesigns;

            }

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
            Product product = null;
            using (_context)
            {
                
                product = _context.product.Where(e => e.Product_ID == ProductId).Include(e => e.productDesign)
                    .Include(e => e.product_images).First();
                //foreach (ProductImages pri in product.Image_Urls)
                //{
                //    product.Image_Urls.Remove(pri);
                //}
                //foreach (ProductDesign pri in product.productDesign)
                //{
                //    product.productDesign.Remove(pri);
                //}
                _context.product.Remove(product);
                _context.SaveChanges();

            }


            return "Can Not  delete ";
        }

      

        public AddProductReponse ExistingData()
        {
             AddProductReponse addProductResponse = new AddProductReponse();
            var catList = _context.categories.ToList();
            var colList = _context.productColor.ToList();
            var sizeList = _context.productSize.ToList();
            var fabricList = _context.productfabric.ToList();
            var stichingList = _context.productstichingtype.ToList();

            addProductResponse.ListOfCategories = catList;
            addProductResponse.ProductColor = colList;
            addProductResponse.ProductSizes = sizeList;
            addProductResponse.ProdctFabrics = fabricList;
            addProductResponse.ProductStichingTypes = stichingList;


            return addProductResponse;

        }

        public (List<ProductResponse>,PagedList<Product>) GeAllProducts(HttpRequest req,ProductPagingParameters productPagingParameters)
        {
            //    var listOfProducts = _context.product
            //        .Skip((productPagingParameters.PageNumber - 1) * productPagingParameters.PageSize)
            //.Take(productPagingParameters.PageSize)

            //  .ToList();

            PagedList<Product> listOfProducts; ;
            using (_context)
            {
                 _context.product.Include(acc => acc.Category).ToList();
                _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.product_design_images).ThenInclude(acc => acc.ProductImage).ToList();
                _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.productColor).ToList();
                _context.product.Include(acc => acc.productDesign).ThenInclude(acc => acc.productSize).ToList();

                _context.product.Include(acc => acc.product_images).ToList();
                _context.product.Include(acc => acc.StichingType).ToList();
                _context.product.Include(acc => acc.Fabric).ToList();
                _context.product.Include(acc => acc.Vendor).ToList();

                listOfProducts = PagedList<Product>.ToPagedList(_context.product, productPagingParameters.PageNumber, productPagingParameters.PageSize);


            }

            List<ProductResponse> ListOfProductResponse = new List<ProductResponse>();
           foreach (Product prd in listOfProducts)
            {
                ListOfProductResponse.Add(new ProductResponse(prd,req));
            }

            
            return (ListOfProductResponse,listOfProducts);


        }

        public List<ProductDesign> GetDesignsForGivenProduct(int Id)
        {
          // var listOfDesign = (from s in _context.productDesign
          //                    where s.Product_Id == Id
           //                   select s).ToList();

            return null;
        }

        public string UpdateProduct(ProdcutRequest prdReq)
        {
            throw new NotImplementedException();
        }

        public List<string> UploadImage(List<IFormFile> Img, IWebHostEnvironment webHostEnvironment,string prdUniqueFolderName, string MaxproductImagId)
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

        public CostCalculateResponse CostWithTax(CostCalculateRequest costCalculateRequest)
        {
            CostCalculateResponse costCalculateResponse = new CostCalculateResponse();
            int tempCustCost = costCalculateRequest.costprice + costCalculateRequest.VendorShippingCost + costCalculateRequest.CustomerShippingCost + costCalculateRequest.CustomerMarginRupees;
            int tempTraderCost = costCalculateRequest.costprice + costCalculateRequest.VendorShippingCost + costCalculateRequest.CustomerShippingCost + costCalculateRequest.TraderMarginRupees;
            int taxpercent = 0;
            int taxpercentTrader = 0;
            if (_context.prd_tax_percentage.Where(e => ((e.productstichingtypeId == costCalculateRequest.prdStichingType) && (e.taxtype == TaxTypes.GST))).FirstOrDefault() != null)
            {
                if ((costCalculateRequest.costprice + costCalculateRequest.CustomerMarginRupees) > 1000)
                {
                    taxpercent = _context.prd_tax_percentage.Where(e => ((e.productstichingtypeId == costCalculateRequest.prdStichingType) && (e.taxtype == TaxTypes.GST_OverMargin))).FirstOrDefault().taxpercentage;

                }
                else
                {

                    taxpercent = _context.prd_tax_percentage.Where(e => (e.productstichingtypeId == costCalculateRequest.prdStichingType) && (e.taxtype == TaxTypes.GST)).FirstOrDefault().taxpercentage;
                }
                if ((costCalculateRequest.costprice + costCalculateRequest.TraderMarginRupees) > 1000)
                {
                    taxpercentTrader = _context.prd_tax_percentage.Where(e => ((e.productstichingtypeId == costCalculateRequest.prdStichingType) && (e.taxtype == TaxTypes.GST_OverMargin))).FirstOrDefault().taxpercentage;

                }
                else
                {

                    taxpercentTrader = _context.prd_tax_percentage.Where(e => (e.productstichingtypeId == costCalculateRequest.prdStichingType) && (e.taxtype == TaxTypes.GST)).FirstOrDefault().taxpercentage;
                }
            }
            else
            {
                taxpercent = _context.prd_tax_percentage.Where(e => (e.productstichingtypeId == costCalculateRequest.prdStichingType) && (e.taxtype == TaxTypes.GST)).FirstOrDefault().taxpercentage;
                taxpercentTrader = taxpercent;
            }
            
            costCalculateResponse.CustomerPrice = tempCustCost + (tempCustCost * taxpercent) / 100;
            costCalculateResponse.TraderPrice = tempTraderCost + (tempTraderCost * taxpercentTrader) / 100;
            return costCalculateResponse;





        }

        public string ActivateProduct(int Id)
        {
           var p = _context.product.Where(x => x.Product_ID == Id).FirstOrDefault();
            if (p != null)
            {
                p.IsActive = true;

                _context.SaveChanges();
                return "Success";

            }
            else {
                return "No Product is there with given ID";
            }
            
           
           
        }

        public string DeactivateProduct(int Id)
        {
           var p= _context.product.Where(x => x.Product_ID == Id).FirstOrDefault();
            if (p != null)
            {
                p.IsActive = false;
                _context.SaveChanges();
                return "Success";
            }
            else
            {
                return "No Product is there with given ID";
            }
            
            
        }

        public void AddWaterMarkToTheImages(string filepath, string MaxproductImagId,IFormFile Img)
        {
            string folderName = Path.GetDirectoryName(filepath);

            string productSpecifiPathWatermark = Path.Combine(folderName, "watermark");
            if (!Directory.Exists(productSpecifiPathWatermark))
            {
                Directory.CreateDirectory(productSpecifiPathWatermark);
            }
            using (var fileStream = new FileStream(filepath, FileMode.Open))
            {
                
                var watermarkedStream = new MemoryStream();
                using (var imgWaterMark = Image.FromStream(fileStream))
                {
                    using (var graphic = Graphics.FromImage(imgWaterMark))
                    {
                        var font = new Font(FontFamily.GenericSansSerif, 90, FontStyle.Bold, GraphicsUnit.Pixel);
                        var color = Color.FromArgb(128, 143, 100, 4);
                        var brush = new SolidBrush(color);
                        var point = new Point(90, 1000);

                        graphic.DrawString(MaxproductImagId.ToString(), font, brush, point);
                        imgWaterMark.Save(watermarkedStream, ImageFormat.Png);
                    }
                    imgWaterMark.Save(productSpecifiPathWatermark + "/" + Path.GetFileName(filepath) );

                }







            }
           


        }


    }
}
