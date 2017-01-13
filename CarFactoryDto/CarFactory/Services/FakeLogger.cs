using CarFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CarFactory.Services
{
    public class FakeLogger: Ilogger
    {
        public void Error(Exception ex, string additionalInfo = null)
        {
            Trace.TraceError($"{additionalInfo ?? "Exception info"}:{Environment.NewLine}{ex}");
        }
    }
}