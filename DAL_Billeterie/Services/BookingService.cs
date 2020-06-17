using DAL_Billeterie.Repositories;
using Microsoft.Extensions.Configuration;
using Models.Booking;
using Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace DAL_Billeterie.Services
{
    public class BookingService : Service, IBooking
    {
        public BookingService(IConfiguration config) : base(config)
        {
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public Booking GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void RegisterBooking(Booking book)
        {
            using (SqlConnection connec = new SqlConnection(StringConnec))
            {

                using (SqlCommand cmd = new SqlCommand("AddBooking", connec))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("idUser", book.UserID);
              

                    connec.Open();
                    int IDBooking = (int)cmd.ExecuteScalar();
                    foreach (var item in book.list)
                    {
                        using (SqlCommand cmd1 = new SqlCommand("AddBookingSelection", connec))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure; 

                            cmd1.Parameters.AddWithValue("idBooking", IDBooking);
                            cmd1.Parameters.AddWithValue("idEvent", item.EventID);                       
                            
                            int IDBookingSelection = (int)cmd1.ExecuteScalar();
                            foreach (var item2 in item.listTicket)
                            {
                                using (SqlCommand cmd2 = new SqlCommand("AddBookingTicket", connec))
                                {
                                    cmd2.CommandType = CommandType.StoredProcedure;

                                    cmd2.Parameters.AddWithValue("idBooking", IDBookingSelection);
                                    cmd2.Parameters.AddWithValue("idTicket", item2.TicketID);
                                    cmd2.Parameters.AddWithValue("qty", item2.Qty);
                                    
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                }
            }
        }

        public void Update(int id, EditUser t)
        {
            throw new NotImplementedException();
        }
    }
}
