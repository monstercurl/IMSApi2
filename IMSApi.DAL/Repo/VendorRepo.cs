
using IMSApi.EntityModel.DTO.VendorDetails;
using IMSApi.EntityModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using IMSApi.DAL.Common;
using IMSApi.EntityModel.IRepo;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace IMSApi.DAL.Repo
{
   public class VendorRepo : IVendoRepo
    {
        IMSApiDbContext _context;

        public VendorRepo(IMSApiDbContext context)
        {
            _context = context;
        }
        public string AddVendor(Vendor vnd)
        {
          
            _context.Vendor.Add(vnd);
            _context.SaveChanges();
            return "added";
        }

        public string Delete(int id)
        {
            var data = _context.Vendor.Where(m => m.Id == id).FirstOrDefault();
            if (data != null)
            {
                _context.Vendor.Remove(data);
                _context.SaveChanges();
                return "deleted";
            }
            return "deleted";
        }

      

        public Vendor GetVendorById(int Id)
        {
            var res = _context.Vendor.Where(m => m.Id == Id).FirstOrDefault();
            return res;
        }

       
        public string Update(int id, VendorModel vnd)
        {

            var data = _context.Vendor.FirstOrDefault(x => x.Id == id);

            // Checking if any such record exist  
            if (data != null)
            {
                
                data.Vendor_name = vnd.Vendor_name;
                data.Supplier_code = vnd.Supplier_code;
                data.Store_name = vnd.Store_name;
                data.Website = vnd.Website;
                data.Gstin = vnd.Gstin;
                data.IsDeleted = vnd.IsDeleted;
                _context.SaveChanges();
                
            }
            return "updated";




        }
        }
    }
