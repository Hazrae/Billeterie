using System;
using System.Collections.Generic;
using System.Text;

namespace Models.User
{
    public class UserCheckOut
    {
        public int UserID { get; set; }
        public string UserMail { get; set; }

        public long? CB_Num { get; set; }
        public DateTime CB_Valid { get; set; }
    }
}
