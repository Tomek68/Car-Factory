using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CarFactory.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ResponseHttpStatusCodeAttribute : Attribute
    {
        public HttpStatusCode[] HttpStatusCodes { get; set; }
        public ResponseHttpStatusCodeAttribute(params HttpStatusCode[] httpStatusCodes)
        {
            HttpStatusCodes = httpStatusCodes;
        }
    }
}