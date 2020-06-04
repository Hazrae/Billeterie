using DAL_Billeterie.Repositories;
using Microsoft.Extensions.Configuration;
using Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;

namespace DAL_Billeterie.Services
{
    public class UserService : Service, IUser
    {
        public UserService(IConfiguration config) : base(config) { }

        public void Create(User u)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User u)
        {
            throw new NotImplementedException();
        }

        public User Login(LoginUser lu)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdatePassword(UserPassword up)
        {
            throw new NotImplementedException();
        }

        public void AddCard(UserCard uc)
        {
            throw new NotImplementedException();
        }
    }
}
