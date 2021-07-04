using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Model;

namespace MISA.CukCuk.Web.EntitiesController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UnitsController : BaseEntitiesController<Unit>
    {
        IBaseBL<Unit> _baseBL;
        public UnitsController(IBaseBL<Unit> baseBL) : base(baseBL)
        {
            _baseBL = baseBL;
        }
    }
}
