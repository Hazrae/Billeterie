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
    public class AuthController : BaseController
    {
        public AuthController(IRSAEncryption encrypt, IUser userService) : base(encrypt, userService) { }

        [Route("GetKey")]
        public byte[] GetKey()
        {

            return _encrypt.PublicBinaryKey;
        }
    }
}