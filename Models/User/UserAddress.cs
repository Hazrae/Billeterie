namespace Models.User
{
    public class UserAddress
    {
        public int UserID { get; set; }
        public int Address_Num { get; set; }
        public string Address_Street { get; set; }
        public string Address_City { get; set; }
        public int Address_ZIP { get; set; }
        public string Country { get; set; }
    }
}