using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Tickets
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        //public int QtyAvailable { get; set; }

    }
}
