using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryDto
{
    public class Car : Vehicle
    {
        public String Name { get; set; }
        public String Brand { get; set; }
        public List<Component> Components { get; set; }
    }
}
