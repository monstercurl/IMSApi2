using IMSApi.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMSApi.DAL.IRepo
{
    public interface IMSDbCOntext
    {
        public string AddVendor(Vendor vendor);
        public string GetVendorName(int Id);
    }
}
