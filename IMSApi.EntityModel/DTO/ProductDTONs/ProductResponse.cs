using IMSApi.EntityModel.Entities;
using IMSApi.EntityModel.Entities.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IMSApi.EntityModel.DTO.ProductDTONs
{
    public class ProductResponse
    {
        public ProductResponse() { }
        public long Product_ID { get; set; }
        public Categories Category { get; set; }
        public ICollection<ProductDesignResponse> prdDesignRes { get; set; }
        public ProductFabric Fabric { get; set; }
        public ProductStichingType StichingType { get; set; }
        public string Description { get; set; }
        public ICollection<ProductImagesRespose> Image_Urls { get; set; }

        public int Cost_Price { get; set; }

        public int Selling_price { get; set; }
        public Vendor Vendor { get; set; }
        public DateTime AddDate { get; set; }
       public TimeSpan AddTime { get; set; }
         public DateTime? UpdateDate { get; set; }
        public TimeSpan? UpdateTime { get; set; }

        public int CustomerShippingCost { get; set; }
        public int VendorShippingCost { get; set; }
        public int TraderMarginRupees { get; set; }
        public int TraderPrice { get; set; }
        public int CustomerMarginRupees { get; set; }
        public int CustomerPrice { get; set; }
        public string ProductImageDir { get; set; }
        public bool IsActive { get; set; }
        public ProductResponse(Product prd,HttpRequest req) {
            Product_ID = prd.Product_ID;
            Category = prd.Category;
            StichingType = prd.StichingType;
            Fabric = prd.Fabric;
            StichingType = prd.StichingType;
            Description = prd.Description;
            Cost_Price = prd.Cost_Price;
            AddTime = prd.AddTime;
            CustomerMarginRupees = prd.CustomerMarginRupees;
            CustomerShippingCost = prd.CustomerShippingCost;
            TraderMarginRupees = prd.TraderMarginRupees;
            VendorShippingCost = prd.VendorShippingCost;Cost_Price = prd.Cost_Price;
            IsActive = prd.IsActive;
            ProductImageDir = prd.ProductImageDir;
            UpdateTime = prd.UpdateTime;

            Vendor = prd.Vendor;
            AddDate = prd.AddDate;
            UpdateDate = prd.UpdateDate;
            CustomerPrice = prd.CustomerPrice;
            TraderPrice = prd.TraderPrice;
            
           
            prdDesignRes = new List<ProductDesignResponse>();

            Image_Urls = new List<ProductImagesRespose>();
            foreach (ProductImages PrdDesign in prd.product_images)
            {
                ProductImages PrdImg = PrdDesign;
                Image_Urls.Add(new ProductImagesRespose() { id = PrdImg.id,url = String.Format("{0}://{1}{2}/images/{3}/{4}", req.Scheme,req.Host,req.PathBase,PrdImg.folderName,Path.GetFileName(PrdImg.Physicalurl)) });

            }
            foreach (ProductDesign PrdDes in prd.productDesign)
            {
                
                
                List<ProductImagesRespose> p = new List<ProductImagesRespose>();
                if(PrdDes.product_design_images.Count() > 0) { 
                 p = (List<ProductImagesRespose>)(from pop in PrdDes.product_design_images
                                                  select new ProductImagesRespose() { id = pop.ProductImagesId, url = String.Format("{0}://{1}{2}/images/{3}/{4}", req.Scheme, req.Host, req.PathBase, pop.ProductImage.folderName, Path.GetFileName(pop.ProductImage.Physicalurl)) }).ToList();

                }
                prdDesignRes.Add(new ProductDesignResponse() { Id = PrdDes.Id,
                    productColor = PrdDes.productColor, productSize = PrdDes.productSize, Quantity = PrdDes.Quantity, Image_Urls = p});

            }



        }


    }
    public class ProductDesignResponse
    {
        public long Id { get; set; }

        public ProductColor productColor { get; set; }
        public ProductSize productSize { get; set; }

        public ICollection<ProductImagesRespose> Image_Urls { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductImagesRespose
    {

        public int id { get; set; }
        public string url { get; set; }
    }


}
