using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL_Billeterie.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toolbox.Cryptography;

namespace API_Billeterie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IRSAEncryption _encrypt;
        protected IUser _userService;
        public BaseController(IRSAEncryption encrypt, IUser userService)
        {
            _encrypt = encrypt;
            _userService = userService;
        }
    }
}