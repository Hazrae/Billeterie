using System;
using System.Collections.Generic;
using System.Text;

namespace Models.User
{
    public class UserPassword
    {
        public int UserID { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
    }

}
