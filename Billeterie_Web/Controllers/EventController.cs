using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billeterie_Web.Infrastructure;
using Billeterie_Web.Utils;
using Microsoft.AspNetCore.Mvc;
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
            //get 5 events par rapport à l'offset
            //les process et affichage dans ma vue
            // pagination +5 offset


             return View();
        }
    }
}