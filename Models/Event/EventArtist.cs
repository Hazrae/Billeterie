using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Event
{
    public class EventArtist
    {
        public int EventID { get; set; }
        public DateTime EventDate { get; set; }
        public string EventName { get; set; }   
        public int LocationID { get; set; }
        public string LocationName { get; set; }
    }
}
