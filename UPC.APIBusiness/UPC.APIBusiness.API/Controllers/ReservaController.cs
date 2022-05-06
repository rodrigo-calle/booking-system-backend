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

namespace API
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/reserva")]
    [ApiController]
    public class ReservaController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IReservaRepository __ReservaRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservaRepository"></param>
        public ReservaController(IReservaRepository reservaRepository)
        {
            __ReservaRepository = reservaRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertReserva(EntityReserva[] reserva)
        {
            var ret = __ReservaRepository.Insert(reserva);
            return Json(ret);
        }
    }
}
