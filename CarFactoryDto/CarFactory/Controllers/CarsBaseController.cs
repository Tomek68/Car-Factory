using CarFactory.Constants;
using CarFactory.Interfaces;
using CarFactory.Services;
using CarFactoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace CarFactory.Controllers
{
    public class CarsBaseController : ApiController
    {
        private readonly ClaimsIdentity _claimsIdentity;
        public Ilogger Logger { get; }

        protected CarsBaseController()
        {
            _claimsIdentity = RequestContext.Principal.Identity as ClaimsIdentity;
            Logger = new FakeLogger();
        }
        protected static readonly Dictionary<int, Component> ComponentsForCar =
    new Dictionary<int, Component>
    {
        [1] = new Component { Id = 1, Type = "Engine" },
        [2] = new Component { Id = 2, Type = "Gear" },
        [3] = new Component { Id = 3, Type = "SteeringWheel" },
        [4] = new Component { Id = 4, Type = "Door" },

    };


        protected static readonly Dictionary<int, Car> Cars =
            new Dictionary<int, Car>
            {
                [1] = new Car
                {
                    Id = 1,
                    Name = "Rav4",
                    Brand = "Toyota",
                    WheelsNumber = 6,
                    Components = new List<Component>()
                    {
                        ComponentsForCar[1],
                        ComponentsForCar[2]
                    }
                },
                [2] = new Car
                {
                    Id = 2,
                    Name = "Impreza",
                    Brand = "Subaru",
                    WheelsNumber = 6,
                    Components = new List<Component>()
                    {
                        ComponentsForCar[2],
                        ComponentsForCar[4]
                    }
                },
                [3] = new Car
                {
                    Id = 3,
                    Name = "Panda",
                    Brand = "Fiat",
                    WheelsNumber = 3,
                    Components = new List<Component>()
                    {
                        ComponentsForCar[1],
                        ComponentsForCar[2],
                        ComponentsForCar[3],
                        ComponentsForCar[4]
                    }
                },

            };


        protected string Device => _claimsIdentity.IsAuthenticated
            ? _claimsIdentity.FindFirst(ApiConstants.ClaimDevice).Value
            : string.Empty;
    }
}