using IMSApi.DAL.IRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMSApi.EntityModel.IRepo
{
    public interface IUnitOfWorK
    {
        IMSDbCOntext _vendorRepo { get; }
        int complete();


    }
}
