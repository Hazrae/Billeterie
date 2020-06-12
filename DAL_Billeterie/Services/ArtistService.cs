using DAL_Billeterie.Repositories;
using Microsoft.Extensions.Configuration;
using Models.Artist;
using Models.Event;
using Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL_Billeterie.Services
{
    public class ArtistService : Service, IArtist
    {
        protected ArtistService(IConfiguration config) : base(config)
        {
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Artist> GetAll()
        {
            throw new NotImplementedException();
        }

        public Artist GetArtist(int id)
        {
            // Get 3 events based on an offset
            using (SqlConnection connec = new SqlConnection(StringConnec))
            {

                using (SqlCommand cmd = new SqlCommand("GetOneArtist", connec))
                {                    
                    Artist artist = new Artist();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    //execution
                    connec.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            artist.ArtistID = (int)dr["ArtistID"];
                            artist.ArtistName = dr["Name"].ToString();
                            artist.ArtistPhoto = dr["Photo"].ToString();
                            artist.ArtistDesc = dr["Desc"].ToString();

                            using (SqlCommand cmd1 = new SqlCommand("GetEventsByArtist", connec))
                            {                               
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("id", id);
                                //execution
                                connec.Open();
                                using (SqlDataReader dr1 = cmd.ExecuteReader())
                                {
                                    while (dr.Read())
                                    {
                                        artist.ListEvent.Add(new EventArtist
                                        {
                                            EventID = (int)dr["EventID"],
                                            EventName = dr["Name"].ToString(),
                                            EventDate = (DateTime)dr["Date"],
                                            LocationID = (int)dr["LocationID"],
                                            LocationName = dr["location"].ToString()
                                        });
                                    }
                                }
                                return artist;
                            }
                        }
                    }
                    return artist;
                }
            }
        }

        public Artist GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, EditUser t)
        {
            throw new NotImplementedException();
        }
    }
}
