using Billeterie_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billeterie_Web.Infrastructure
{
    public interface ISessionManager
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public List<BookingViewModel> Cart { get; set; }
        public string CB_Num { get; set; }

        public void Abandon();
    }
}
