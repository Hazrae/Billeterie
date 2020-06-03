using System;

namespace Models.User
{
    public class UserCard
    {
        public int UserID { get; set; }
        public long CB_Num { get; set; }
        public DateTime CB_Valid { get; set; }
        public int CB_Code { get; set; }

    }
}