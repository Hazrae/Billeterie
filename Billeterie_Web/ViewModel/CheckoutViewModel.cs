using Billeterie_Web.Infrastructure;
using Billeterie_Web.Utils;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billeterie_Web.ViewModel
{
    public class CheckoutViewModel
    {
        public List<BookingViewModel> listBVM;
        public UserCheckOut user;

        public CheckoutViewModel(ISessionManager SessionManager, IAPIConsume ConsumeInstance)
        {
            listBVM = new List<BookingViewModel>();
            listBVM = SessionManager.Cart;
            user = ConsumeInstance.Get<UserCheckOut>("User/GetCheckOutInfo/", SessionManager.Id);
        }
    }
}
