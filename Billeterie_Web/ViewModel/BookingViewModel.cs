using Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billeterie_Web.ViewModel
{
    public class BookingViewModel
    {
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string LocationName { get; set; }
        public string LocationDesc { get; set; }
        public List<Ticket> listTicket { get; set; }
        public SelectedTicket[] tabSelectedTickets { get; set; }        

        public BookingViewModel()
        {
            listTicket = new List<Ticket>();          
        }
    }
}
