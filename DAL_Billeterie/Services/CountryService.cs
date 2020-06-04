using DAL_Billeterie.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL_Billeterie.Services
{
    public class CountryService : Service, ICountry
    {
        public CountryService(IConfiguration config) : base(config) { }

        public List<SelectListItem> GetAll()
        {        
                        
            using (SqlConnection connec = new SqlConnection(StringConnec))
            {
                List<SelectListItem> list = new List<SelectListItem>();
                using (SqlCommand cmd = new SqlCommand("GetAllCountries", connec))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connec.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            SelectListItem item = new SelectListItem();
                            item.Text = dr["Name"].ToString();
                            item.Value = dr["CountryID"].ToString();
                            list.Add(item);
                        }
                    }
                }
                return list;
            }
        }
    }
}
