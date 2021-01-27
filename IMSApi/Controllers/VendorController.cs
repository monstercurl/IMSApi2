using IMSApi.DAL;
using IMSApi.DAL.Common;
using IMSApi.DAL.IRepo;
using IMSApi.EntityModel.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class VendorController : ControllerBase
    {
        IMSApiDbContext _vendor;
        private IConfiguration _cnfig;
        public VendorController(IMSApiDbContext _dn, IConfiguration _config)
        {
            _vendor = _dn; _cnfig = _config;
 }
        [AllowAnonymous]
        [Route("[controller]/api")]
        [HttpGet]
        public string Set()
        {
            // return new JwtService(_cnfig).GenerateSecurityToken("ashu@gmail.com");
            return "Yes";
        }



        [HttpPost]
        public string Get()
        {
            return _vendor.Vendors.ToString();
        }

    }
}
