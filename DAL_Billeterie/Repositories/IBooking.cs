using Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Billeterie.Repositories
{
    public interface IBooking : IRepository<Booking>
    {
        public void RegisterBooking(Booking book);
    }
}
