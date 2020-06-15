﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billeterie_Web.Infrastructure
{
    public interface ISessionManager
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Cart { get; set; }
        public void Abandon();
    }
}
