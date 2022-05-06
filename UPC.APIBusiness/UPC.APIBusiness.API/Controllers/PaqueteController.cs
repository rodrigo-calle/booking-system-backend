using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPC.APIBusiness.DBContext.Interface;

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/paquete")]
    [ApiController]
    public class PaqueteController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IPaqueteRepository __PaqueteRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paqueteRepository"></param>
        public PaqueteController(IPaqueteRepository paqueteRepository)
        {
            __PaqueteRepository = paqueteRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar")]
        public ActionResult GetPaquetes()
        {
            var ret = __PaqueteRepository.GetPaquetes();
            return Json(ret);
        }

    }
}
