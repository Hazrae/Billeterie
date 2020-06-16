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

        public void Update(int id, EditUser u)
        {
            //Update User details
            using (SqlConnection connec = new SqlConnection(StringConnec))
            {

                using (SqlCommand cmd = new SqlCommand("UpdateUser", connec))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("mail", u.Mail);
                    cmd.Parameters.AddWithValue("login", u.Login);
                    cmd.Parameters.AddWithValue("birthDate", u.BirthDate);
                    cmd.Parameters.AddWithValue("country", u.SelectedCountry);

                    connec.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public User Login(LoginUser lu)
        {

            //Log an user in through his credentials
            using (SqlConnection connec = new SqlConnection(StringConnec))
            {

                using (SqlCommand cmd = new SqlCommand("LoginUser", connec))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Login", lu.Login);
                    cmd.Parameters.AddWithValue("Password", lu.Password);

                    connec.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        if (dr.Read())
                        {
                            return new User
                            {
                                UserID = (int)dr["UserID"],
                                Mail = dr["Mail"].ToString(),
                                Login = dr["Login"].ToString(),
                                BirthDate = (DateTime)dr["BirthDate"],
                                IsActive = (bool)dr["IsActive"],                               
                                IsAdmin = (bool)dr["IsAdmin"]
                            };
                        }
                        else
                            return new User();
                    }
                }
            }
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetOne(int id)
        {
            // Get a specific user through his ID
            using (SqlConnection connec = new SqlConnection(StringConnec))
            {

                using (SqlCommand cmd = new SqlCommand("GetOne", connec))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    //execution
                    connec.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        return new User
                        {
                            UserID = (int)dr["UserID"],
                            Mail = dr["Mail"].ToString(),
                            Login = dr["Login"].ToString(),
                            BirthDate = (DateTime)dr["BirthDate"],
                            IsActive = (bool)dr["IsActive"],                          
                            IsAdmin = (bool)dr["IsAdmin"],
                            Country = (int)dr["FK_Country"]
                        }; 
                    }
                }
            }
        }

        public int UpdatePassword(int id, UserPassword u)
        {
            using (SqlConnection connec = new SqlConnection(StringConnec))
            {

                using (SqlCommand cmd = new SqlCommand("UpdatePassword", connec))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("oldpassword", u.OldPassword);
                    cmd.Parameters.AddWithValue("password", u.Password);

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);

                    connec.Open();
                    cmd.ExecuteNonQuery();
                    return (int)returnValue.Value;
                }
            }
        }

        public void AddCard(UserCard uc)
        {
            throw new NotImplementedException();
        }

        public UserCard GetCard(int id)
        {
            // Get an user car through his ID
            using (SqlConnection connec = new SqlConnection(StringConnec))
            {

                using (SqlCommand cmd = new SqlCommand("GetCard", connec))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    //execution
                    connec.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        return new UserCard
                        {
                            UserID = id,
                            CB_Num = (long)dr["CB_Num"],
                            CB_Valid = (DateTime)dr["CB_Valid"]
                        }; 
                    }
                }
            }
        }
    }
}
