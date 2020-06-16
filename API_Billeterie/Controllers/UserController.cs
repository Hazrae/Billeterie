using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DAL_Billeterie.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Errors;
using Models.User.Mapper;
using Models.User;
using Toolbox.Cryptography;

namespace API_Billeterie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IRSAEncryption encrypt, IUser userService) : base(encrypt, userService) { }

        [HttpGet]
        [Route("GetCheckOutInfo/{id}")]
        public UserCheckOut GetCheckOutInfo(int id)
        {
            return  _userService.GetCheckOutInfo(id);
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public EditUser Get(int id)
        {
            return _userService.GetOne(id).ToLocal();
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

        [HttpPost]
        [Route("Login")]
        public User Login(LoginUser u)
        {
            string pwDecrypt = _encrypt.Decrypt(Convert.FromBase64String(u.Password));
            u.Password = pwDecrypt;
            return _userService.Login(u);
        }


        // PUT: api/User/5
        [HttpPut("{id}")]
        public UserResponse Put(int id, [FromBody] EditUser u)
        {
            try
            {
                _userService.Update(id, u); ;
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

        // PUT: api/User/PutPw/5
        [HttpPut]
        [Route("ChangePw/{id}")]
        public UserResponse ChangePw(int id, UserPassword u)
        {
            string pwDecrypt = _encrypt.Decrypt(Convert.FromBase64String(u.Password));
            u.Password = pwDecrypt;
            pwDecrypt = _encrypt.Decrypt(Convert.FromBase64String(u.OldPassword));
            u.OldPassword = pwDecrypt;

            int state = _userService.UpdatePassword(id, u); ;
            if (state == 1)
                return new UserResponse { ErrorCode = 3 };
            else
                return new UserResponse();
        }      
        
        [HttpPost]
        [Route("AddCard")]
        public void AddCard(UserCard uc)
        {
            _userService.AddCard(uc);
        }
            
    }
}
