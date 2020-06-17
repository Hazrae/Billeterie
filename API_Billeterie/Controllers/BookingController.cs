using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL_Billeterie.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Booking;
using Toolbox.Cryptography;

namespace API_Billeterie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : BaseController
    {
        public BookingController(IRSAEncryption encrypt, IBooking bookingService) : base(encrypt, bookingService)
        {
        }

        [HttpPost]
        public void Booking(Booking book)
        {
            _bookingService.RegisterBooking(book);
        }
    }
}