using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL_Billeterie.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Booking;
using Models.Event;
using Toolbox.Cryptography;

namespace API_Billeterie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseController
    {
        public EventController(IRSAEncryption encrypt, IEvent eventService) : base(encrypt, eventService)
        {
        }

      
        // GET: api/Event/5
        [HttpGet("{id}")]
        public List<Event> Get(int id)
        {
            return _eventService.GetBy3(id);
        }

        [HttpGet]
        [Route("Booking/{id}")]
        public BookingDetails GetDetails(int id)
        {
            return _eventService.GetBookingDetails(id);
        }

    }
}
