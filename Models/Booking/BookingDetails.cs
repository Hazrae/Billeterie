
using Models.Tickets;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Models.Booking
{
    public class BookingDetails
    {
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string LocationName { get; set; }
        public string LocationDesc { get; set; }
        public List<Ticket> listTicket { get; set; }

        public BookingDetails()
        {
            listTicket = new List<Ticket>();
        }
    }
}
