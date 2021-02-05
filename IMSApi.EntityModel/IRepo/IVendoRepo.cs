using IMSApi.EntityModel;
using IMSApi.EntityModel.DTO.VendorDetails;
using IMSApi.EntityModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMSApi.EntityModel.IRepo
{
    public interface IVendoRepo
    {
        public string AddVendor(Vendor model);

      
        public Vendor GetVendorById(int Id);

        public string Update(int id,VendorModel vnd);

        public string Delete(int id);
    }
}
