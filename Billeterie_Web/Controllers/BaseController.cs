using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billeterie_Web.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Billeterie_Web.Controllers
{
    public class BaseController : Controller
    {
        protected internal IAPIConsume ConsumeInstance { get; set; }
        public BaseController(IAPIConsume apiConsume)
        {
            ConsumeInstance = apiConsume;
        }
     
    }
}