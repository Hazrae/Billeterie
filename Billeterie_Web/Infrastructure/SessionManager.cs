using Billeterie_Web.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billeterie_Web.Infrastructure
{
    internal class SessionManager : ISessionManager
    {
        private ISession Session { get; }

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            Session = httpContextAccessor.HttpContext.Session;
        }

        public int Id
        {
            get { return (Session.GetInt32(nameof(Id)).HasValue) ? Session.GetInt32(nameof(Id)).Value : -1; }
            set { Session.SetInt32(nameof(Id), value); }
        }

        public string Login
        {
            get { return (Session.GetString(nameof(Login)) is null) ? "" : Session.GetString(nameof(Login)); }
            set { Session.SetString(nameof(Login), value); }
        }

        public BookingViewModel Cart
        {
            get
            {
                string json = Session.GetString(nameof(Cart));
                return (json is null) ? null : JsonConvert.DeserializeObject<BookingViewModel>(json);
            }
            set
            {
                Session.SetString(nameof(Cart), JsonConvert.SerializeObject(value));
            }
        }

        public void Abandon()
        {
            Session.Clear();
        }
    }
}
