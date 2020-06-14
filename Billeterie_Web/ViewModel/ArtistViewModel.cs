using Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billeterie_Web.ViewModel
{
    public class ArtistViewModel
    {
        public ArtistViewModel()
        {
            ListEvent = new List<EventArtist>();
        }

        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string ArtistDesc { get; set; }
        public string ArtistPhoto { get; set; }
        public List<EventArtist> ListEvent { get; set; }
    }
}
