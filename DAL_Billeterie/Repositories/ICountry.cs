using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL_Billeterie.Repositories
{
    public interface ICountry
    {
        List<SelectListItem> GetAll();
    }
}
