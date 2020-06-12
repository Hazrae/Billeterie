﻿using Models.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Billeterie.Repositories
{
    interface IEvent : IRepository<Event>
    {
        List<Event> GetBy3(int offset);
    }
}
