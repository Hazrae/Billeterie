using DAL_Billeterie.Repositories;
using Microsoft.Extensions.Configuration;
using Models.Event;
using Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL_Billeterie.Services
{
    public class EventService : Service, IEvent
    {
        public EventService(IConfiguration config) : base(config)
        {
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Event> GetBy3(int offset)
        {

            // Get 3 events based on an offset
            using (SqlConnection connec = new SqlConnection(StringConnec))
            {

                using (SqlCommand cmd = new SqlCommand("GetEventsBy3", connec))
                {
                    List<Event> list = new List<Event>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("offset", offset);
                    //execution
                    connec.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {                        
                        while (dr.Read())
                        {
                            list.Add( new Event
                            {
                                EventID = (int)dr["EventID"],
                                EventName = dr["Name"].ToString(),
                                DateEvent = (DateTime)dr["Date"],
                                ArtistID = (int)dr["ArtistID"],
                                ArtistName = dr["artist"].ToString(),
                                ArtistPhoto = dr["Photo"].ToString(),
                                LocationID = (int)dr["LocationID"],
                                LocationName = dr["location"].ToString()
                            });                            
                        }
                    }
                    return list;
                }
            }
        }

        public Event GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, EditUser t)
        {
            throw new NotImplementedException();
        }
    }
}
