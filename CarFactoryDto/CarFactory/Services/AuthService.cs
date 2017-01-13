using CarFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarFactoryDto;

namespace CarFactory.Services
{
    public class AuthService : IAuthService
    {
        private static readonly Dictionary<string, User> Users =
    new Dictionary<string, User>
    {
        ["janw"] = new User { FirstName = "Jan", LastName = "Wiśnia", UserName = "janw", Password = "wisnia1919" },
    };

        public bool AuthenticateUser(string userName, string password, out User user)
        {
            if (!Users.TryGetValue(userName, out user))
            {
                return false;
            }

            if (user.Password != password)
            {
                return false;
            }

            return true;
        }

    }
}