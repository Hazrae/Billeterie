using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL_Billeterie.Repositories;
using DAL_Billeterie.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Toolbox.Cryptography;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace API_Billeterie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseController
    {
        ICountry _countryService;
        public CountryController(IRSAEncryption encrypt, IUser userService, ICountry countryService) : base(encrypt, userService)
        {
            _countryService = countryService;
        }
        public List<SelectListItem> GetAll()
        {

            return _countryService.GetAll();
        }
    }
}