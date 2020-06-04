using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DAL_Billeterie.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Errors;
using Models.User;
using Toolbox.Cryptography;

namespace API_Billeterie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IRSAEncryption encrypt, IUser userService) : base(encrypt, userService) { }
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public UserResponse Post([FromBody] RegisterUser ru)
        {
            try
            {
                string pwDecrypt = _encrypt.Decrypt(Convert.FromBase64String(ru.Password));
                ru.Password = pwDecrypt;
                _userService.Create(ru);
            }
            catch (SqlException e)
            {
                switch (e.Number)
                {
                    case 2627:
                        {
                            if (e.Message.Contains("mail"))
                                return new UserResponse { ErrorCode = 1 };
                            else
                                return new UserResponse { ErrorCode = 2 };
                        }
                }
            }
            return new UserResponse();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
