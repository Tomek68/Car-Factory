using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryDto
{
    public class Component
    {
        public int Id { get; set; }
        [Required]
        public String Type { get; set; }
    }
}
