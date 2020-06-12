using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL_Billeterie.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        //// GET: api/Event
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Event/5
        [HttpGet("{id}")]
        public List<Event> Get(int id)
        {
            return _eventService.GetBy3(id);
        }

        //// POST: api/Event
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Event/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
