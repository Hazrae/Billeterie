using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Event
{
    public class Event
    {
        int EventID { get; set; }
        DateTime DateEvent { get; set; }
        int LocationID { get; set; }
        string LocationName { get; set; }
        int ArtistID { get; set; }
        int ArtistName { get; set; }
    }
}
