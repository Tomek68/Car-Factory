using CarFactory.Attributes;
using CarFactoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CarFactory.Controllers
{
    [ValidateModelState]
    [RoutePrefix("api/carFactory")]
    public class CarsController : CarsBaseController
    {
        [AllowAnonymous]
        [HttpGet, Route("getAllCars")]
        [ResponseHttpStatusCode(HttpStatusCode.OK)]
        [ResponseType(typeof(IEnumerable<Car>))]
        public IHttpActionResult Get()
        {
            return Ok(Cars.Values);
        }

    }
}
