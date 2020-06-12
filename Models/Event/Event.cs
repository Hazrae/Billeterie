using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Event
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public  DateTime DateEvent { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string ArtistPhoto { get; set; }
    }
}
