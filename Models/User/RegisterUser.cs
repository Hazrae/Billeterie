using System;
using System.Collections.Generic;
using System.Text;

namespace Models.User
{
    public class RegisterUser
    {      
        public string Login { get; set; }
        public string Password { get; set; }   
        public string Mail { get; set; }
        public DateTime BirthDate { get; set; }
        public int Country { get; set; }
    }
}
