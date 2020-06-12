using Billeterie_Web.Utils;
using Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billeterie_Web.ViewModel
{
    public class Eventby3
    {
        public int offset { get; set; }
        public IEnumerable<Event> list { get; set; }

        public Eventby3(IAPIConsume consume, int offset)
        {
            this.offset = offset;
            list = consume.Get<IEnumerable<Event>>("Event/", offset);
        }
    }
}
