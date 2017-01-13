using CarFactory.Attributes;
using CarFactory.Utils;
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
    [SimpleAuthorizeAttribute]
    [ValidateModelState]
    [RoutePrefix("api")]
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
        [AllowAnonymous]
        [HttpGet, Route("GetAllComponents")]
        [ResponseHttpStatusCode(HttpStatusCode.OK)]
        [ResponseType(typeof(IEnumerable<Car>))]
        public IHttpActionResult GetComponents()
        {
            return Ok(ComponentsForCar.Values);
        }
        [AllowAnonymous]
        [HttpGet, Route("{id}", Name = "GetCar")]
        [ResponseHttpStatusCode(HttpStatusCode.OK)]
        [ResponseType(typeof(IEnumerable<Car>))]
        public IHttpActionResult GetCar(int id)
        {
            if (!Cars.ContainsKey(id))
            {
                return NotFound();
            }

            return Ok(Cars[id]);
        }
        [HttpPost, Route("")]
        [ResponseHttpStatusCode(HttpStatusCode.Created)]
        [ResponseType(typeof(Car))]
        public IHttpActionResult Post([FromBody]Car car)
        {
            int maxId = Cars.Keys.Count > 0 ? Cars.Keys.Max() : 0;
            car.Id = ++maxId;
            if(car.Components != null || !car.Components.Any())
            {
                foreach(Component c in car.Components)
                {
                    int maxComponentsID = ComponentsForCar.Keys.Count > 0 ? ComponentsForCar.Keys.Max() : 0;
                    c.Id = ++maxComponentsID;
                    ComponentsForCar.Add(maxComponentsID, c);
                }
                
            }
            Cars.Add(maxId, car);
            return CreatedAtRoute("GetCar", new { id = car.Id }, car);
        }
        [HttpPut, Route("{id}")]
        [ResponseHttpStatusCode(HttpStatusCode.OK, HttpStatusCode.NotFound)]
        public IHttpActionResult Put(int id, [FromBody]Car car)
        {
            Car dbCar;
            if (!Cars.TryGetValue(id, out dbCar))
            {
                return NotFound();
            }

            dbCar.Name = car.Name;
            dbCar.Brand = car.Brand;
            dbCar.WheelsNumber = car.WheelsNumber;
            dbCar.Components = car.Components;

            return Ok();
        }

        /// <summary>
        /// Delete existing Note
        /// </summary>
        /// <param name="id">Note ID</param>
        /// <returns></returns>
        /// 
        [HttpDelete, Route("{id}")]
        [ResponseHttpStatusCode(HttpStatusCode.OK, HttpStatusCode.NotFound)]
        public IHttpActionResult Delete(int id)
        {
            if (!Cars.ContainsKey(id))
            {
                return NotFound();
            }

            Cars.Remove(id);
            return Ok();
        }


    }
}
