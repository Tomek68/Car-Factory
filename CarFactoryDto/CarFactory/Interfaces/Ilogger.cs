using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory.Interfaces
{
    public interface Ilogger
    {
        void Error(Exception ex, string additionalInfo = null);

    }
}
