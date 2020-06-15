using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Billeterie_Web.ViewModel
{
    public class ContactViewModel
    {
        [StringLength(100)]
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}
