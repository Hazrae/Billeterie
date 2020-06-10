using Billeterie_Web.Utils;
using Billeterie_Web.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Billeterie_Web.ViewModel
{
    public class UserEditForm
    {
        [Required]
        public string Login { get; set; }       

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required]
        [AgeValidator(ErrorMessage = "You must have between 12 and 266 years")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int SelectedCountry { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public UserEditForm()
        {
            APIConsume consume = new APIConsume(new Uri("https://localhost:5001/api/"));
            Countries = consume.Get<List<SelectListItem>>("Country");
        }
    }
}
