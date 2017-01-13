using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryDto
{
    public class RefreshToken
    {
        public string UserName { get; set; }

        public DateTime IssuedDate { get; set; }

        public DateTime ExpiresDate { get; set; }

        public string ProtectedTicket { get; set; }

        public string Token { get; set; }
    }

}
