using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Billeterie.Services
{
    public class Service
    {
        protected IConfiguration _config;

        public string StringConnec
        {
            get { return _config.GetConnectionString("BilleterieDB"); }
        }

        protected Service(IConfiguration config)
        {
            _config = config;

        }

    }
}
