﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billeterie_Web.Infrastructure;
using Billeterie_Web.Utils;
using Billeterie_Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Models.Event;
using Vereyon.Web;

namespace Billeterie_Web.Controllers
{
    public class EventController : BaseController
    {
        public EventController(IAPIConsume apiConsume, IFlashMessage flashMessage, ISessionManager session) : base(apiConsume, flashMessage, session)
        {
        }

        public IActionResult Index(int offset = 0)
        {
            //get 3 events par rapport à l'offset
            //les process et affichage dans ma vue
            // pagination +3 offset

            Eventby3 listEvent = new Eventby3(ConsumeInstance, (offset < 0)?0:offset);                 

             return View(listEvent);
        }
    }
}