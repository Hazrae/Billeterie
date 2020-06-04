using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billeterie_Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Vereyon.Web;

namespace Billeterie_Web.Controllers
{
    public class BaseController : Controller
    {
        protected internal IAPIConsume ConsumeInstance { get; set; }
        protected internal IFlashMessage FlashMessage { get; set; }
        public BaseController(IAPIConsume apiConsume, IFlashMessage flashMessage)
        {
            ConsumeInstance = apiConsume;
            FlashMessage = flashMessage;
        }
     
    }
}