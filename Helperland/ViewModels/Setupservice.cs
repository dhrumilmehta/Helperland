using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help.ViewModels
{
    public class Setupservice
    {
        [Required]
        public string ZipCode { get; set; }
    }
}
