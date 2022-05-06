using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/habitacion")]
    public class HabitacionController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IHabitacionRepository __HabitacionRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="habitacionRepository"></param>
        public HabitacionController(IHabitacionRepository habitacionRepository)
        {
            __HabitacionRepository = habitacionRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar")]
        public ActionResult GetHabitaciones()
        {
            var ret = __HabitacionRepository.GetHabitaciones();
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar_agrup")]
        public ActionResult GetHabitacionesAgrup()
        {
            var ret = __HabitacionRepository.GetHabitacionesAgrup();
            return Json(ret);
        }
    }
}
