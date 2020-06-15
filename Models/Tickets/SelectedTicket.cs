using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Tickets
{
    public class SelectedTicket
    {
        public int TicketID { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
}
