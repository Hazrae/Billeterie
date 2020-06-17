using Models.Tickets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Booking
{
    public class Booking
    {
        public int UserID { get; set; }
        public List<BookingSelection> list { get; set; }

        public Booking()
        {
            list = new List<BookingSelection>();
        }
        
    }
}
