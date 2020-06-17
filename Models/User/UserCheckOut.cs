using System;
using System.Collections.Generic;
using System.Text;

namespace Models.User
{
    public class UserCheckOut
    {
        public int UserID { get; set; }
        public string UserMail { get; set; }

        public string CB_Num { get; set; }
        public string CB_Valid { get; set; }
        public string CB_Valid_Enter { get; set; }
        public string CB_Num_Enter { get; set; }
        public int CB_Code_Enter { get; set; }
        public int CB_Code { get; set; }
    }
}
