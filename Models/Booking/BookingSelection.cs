using Models.Tickets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Booking
{
    public class BookingSelection
    {
        public int EventID { get; set; }
        public List<BookingTicket> listTicket{get;set;}
    }
}
