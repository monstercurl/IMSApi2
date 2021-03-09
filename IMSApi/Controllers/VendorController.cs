using IMSApi.DAL;
using IMSApi.EntityModel.DTO.VendorDetails;
using IMSApi.EntityModel.Entities;
using IMSApi.EntityModel.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace IMSApi.Controllers
{
    [ApiController]
   
    [Route("[controller]")]
    public class VendorController : ControllerBase
    {
        IMSApiDbContext _vendor;
        private IConfiguration _cnfig;
        IVendoRepo _ven;

      
        public VendorController(IMSApiDbContext _dn, IConfiguration _config,IVendoRepo _vend)
        {
            _vendor = _dn; _cnfig = _config;_ven = _vend;
 }
        [HttpGet("List")]
        public ActionResult getlist()
        {
            var res = _vendor.vendor.ToList();
            return Ok(res);
        }
        [HttpPost("Add")]
        public ActionResult Add(Vendor vnd)
        {
            var res = _ven.AddVendor(vnd);
            return Ok(res);

        }
        [HttpPost("Update")]
        public ActionResult Update(VendorModel vn,int id)
        {
            var res = _ven.Update(id,vn);
            return Ok(res);
        }
       
        [HttpPost("Delete")]
        public ActionResult Delete(int id)
        {
            var res = _ven.Delete(id);
            return Ok(res);
        }
        [HttpPost("GetByID")]
       public ActionResult GetByID(int id)
        {
            var res = _ven.GetVendorById(id);
            return Ok(res);
        }
    }
}
