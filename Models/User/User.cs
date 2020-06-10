using System;
using System.Collections.Generic;
using System.Text;

namespace Models.User
{
    public class User
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public DateTime BirthDate { get; set; }
        public Boolean IsAdmin { get; set; }
        public Boolean IsActive { get; set; }
        public int Country { get; set; }
        public long CB_Num { get; set; }
        public DateTime CB_Valid { get; set; }
        public int CB_Code { get; set; }

    }

}
