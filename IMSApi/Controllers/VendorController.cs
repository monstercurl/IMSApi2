using IMSApi.DAL;
using IMSApi.DAL.IRepo;
using IMSApi.EntityModel.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendorController : ControllerBase
    {
        IMSApiDbContext _vendor;
        public VendorController(IMSApiDbContext _dn)
        { _vendor = _dn; }
        

       

        [HttpGet]
        public string Get()
        {
            return _vendor.Vendors.ToString();
        }
    }
}
