using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using MISA.Common;
using MISA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.EntitiesController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StoresController : BaseEntitiesController<Store>
    {
        IBaseBL<Store> _baseBL;
        public StoresController(IBaseBL<Store> baseBL) : base(baseBL)
        {
            _baseBL = baseBL;
        }


    }
}
