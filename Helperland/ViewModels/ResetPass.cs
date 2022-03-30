using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Helperland.ViewModels
{
    public class ResetPass
    {
        public int userID { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string newPassword { get; set; }

        [Required(ErrorMessage = "Please Re-Enter Password")]
        [Compare("newPassword", ErrorMessage ="Passwords do not match!")]
        public string CnfrmnewPassword { get; set; }
    }
}
