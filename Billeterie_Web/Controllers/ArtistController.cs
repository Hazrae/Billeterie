using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billeterie_Web.Infrastructure;
using Billeterie_Web.Utils;
using Billeterie_Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Models.Artist;
using Vereyon.Web;

namespace Billeterie_Web.Controllers
{
    public class ArtistController : BaseController
    {
        public ArtistController(IAPIConsume apiConsume, IFlashMessage flashMessage, ISessionManager session) : base(apiConsume, flashMessage, session)
        {
        }

        public IActionResult Profil(int id)
        {
            ArtistViewModel avm = new ArtistViewModel();
            avm = ConsumeInstance.Get<ArtistViewModel>("Artist/", id);
            return View(avm);
        }

        public IActionResult Wall()
        {
            List<ArtistWallViewModel> list = new List<ArtistWallViewModel>();
            list = ConsumeInstance.Get<List<ArtistWallViewModel>>("Artist");
            return View(list);
        }
    }
}