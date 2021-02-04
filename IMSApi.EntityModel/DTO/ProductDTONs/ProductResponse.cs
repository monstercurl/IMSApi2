using IMSApi.EntityModel.Entities;
using IMSApi.EntityModel.Entities.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace IMSApi.EntityModel.DTO.ProductDTONs
{
    public class ProductResponse
    {
        public ProductResponse() { }
        public long Product_ID { get; set; }
        public Categories Category { get; set; }
        public ICollection<ProductDesignResponse> prdDesignRes { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProductImagesRespose> Image_Urls { get; set; }

        public int Cost_Price { get; set; }

        public int Selling_price { get; set; }
        public Vendor Vendor { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ProductResponse(Product prd,HttpRequest req) {
            Product_ID = prd.Product_ID;
            Category = prd.Category;
            Name = prd.Name;
            Description = prd.Description;
            Cost_Price = prd.Cost_Price;
            Selling_price = prd.Selling_price;
            Vendor = prd.Vendor;
            AddDate = prd.AddDate;
            UpdateDate = prd.UpdateDate;
            prdDesignRes = new List<ProductDesignResponse>();
            Image_Urls = new List<ProductImagesRespose>();
            foreach (ProductImages PrdImg in prd.Image_Urls)
            {
                Image_Urls.Add(new ProductImagesRespose() { id = PrdImg.id,url = String.Format("{0}://{1}{2}/images/{3}/{4}", req.Scheme,req.Host,req.PathBase,PrdImg.folderName,Path.GetFileName(PrdImg.Physicalurl)) });

            }
            foreach (ProductDesign PrdDes in prd.productDesign)
            {
                prdDesignRes.Add(new ProductDesignResponse() { Id = PrdDes.Id, 
                    productColor = PrdDes.productColor,productSize = PrdDes.productSize,Quantity = PrdDes.Quantity });

            }



        }


    }
    public class ProductDesignResponse
    {
        public long Id { get; set; }

        public ProductColor productColor { get; set; }
        public ProductSize productSize { get; set; }


        public int Quantity { get; set; }
    }
    public class ProductImagesRespose
    {

        public int id { get; set; }
        public string url { get; set; }
    }


}
