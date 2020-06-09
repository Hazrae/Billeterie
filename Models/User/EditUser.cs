using System;
using System.Collections.Generic;
using System.Text;

namespace Models.User
{
    public class EditUser
    { 
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public DateTime BirthDate { get; set; }
        public int SelectedCountry { get; set; }
    }
}
