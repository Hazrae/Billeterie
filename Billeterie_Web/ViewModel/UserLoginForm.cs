using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Billeterie_Web.ViewModel
{
    public class UserLoginForm
    {
        [Required]
        [MaxLength(25)]
        public string Login { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
