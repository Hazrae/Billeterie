using DAL_Billeterie.Repositories;
using Microsoft.Extensions.Configuration;
using Models.Errors;
using Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Text;

namespace DAL_Billeterie.Services
{
    public class UserService : Service, IUser
    {
        public UserService(IConfiguration config) : base(config) { }

        public void Create(RegisterUser u)
        {
            using (SqlConnection connec = new SqlConnection(StringConnec))
            {
                //Add user in DB            
                using (SqlCommand cmd = new SqlCommand("AddUser", connec))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("mail", u.Mail);
                    cmd.Parameters.AddWithValue("login", u.Login);
                    cmd.Parameters.AddWithValue("password", u.Password);
                    cmd.Parameters.AddWithValue("birthDate", u.BirthDate);
                    cmd.Parameters.AddWithValue("country", u.Country);
                   
                    connec.Open();
                    cmd.ExecuteNonQuery();
                }
            }
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
