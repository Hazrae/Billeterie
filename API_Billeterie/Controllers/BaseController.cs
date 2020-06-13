using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL_Billeterie.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Toolbox.Cryptography;

namespace API_Billeterie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IRSAEncryption _encrypt;
        protected IUser _userService;
        protected IEvent _eventService;
        protected IArtist _artistService;
        public BaseController(IRSAEncryption encrypt, IUser userService)
        {
            _encrypt = encrypt;
            _userService = userService;
        }

        public BaseController(IRSAEncryption encrypt, IEvent eventService)
        {
            _encrypt = encrypt;
            _eventService = eventService;
        }

        public BaseController(IRSAEncryption encrypt, IArtist artistService)
        {
            _encrypt = encrypt;
            _artistService = artistService;
        }
    }
}