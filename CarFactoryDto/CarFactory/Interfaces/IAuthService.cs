using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarFactoryDto;

namespace CarFactory.Interfaces
{
    public interface IAuthService
    {
        bool AuthenticateUser(string userName, string password, out User user);
    }
}