using IMSApi.EntityModel.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.DAL.Repo
{
    public class ProductService : IProductService
    {
        IMSApiDbContext _context ;
        public ProductService(IMSApiDbContext context) 
        {
            _context = context;
        }
        public string AddProduct(string name, string brand)
        {
            _context.product.Add(new EntityModel.Entities.Product()
            { Name = name, color = brand});
            _context.SaveChanges();
            return "Added Successfully";
            
        }
    }
}
