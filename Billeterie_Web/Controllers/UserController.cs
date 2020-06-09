using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Billeterie_Web.Utils;
using Billeterie_Web.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vereyon.Web;
using Models.Errors;
using Models.User;
using Toolbox.Cryptography;
using Billeterie_Web.Infrastructure;
using Billeterie_Web.Utils.Interfaces;
using Microsoft.Extensions.Configuration;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;

namespace Billeterie_Web.Controllers
{
    public class UserController : BaseController
    {
        private IRSAEncryption _encrypt;
        private IGoogleToken _googleToken;
        private IConfiguration _config;
        public UserController(IAPIConsume apiConsume, IFlashMessage flash, ISessionManager session, IGoogleToken googleToken, IConfiguration config) : base(apiConsume, flash, session) 
        {
            _googleToken = googleToken;
            _config = config;
        }

        // GET: User/Create
        [AnonymousRequired]
        public ActionResult Create()
        {
            UserForm user = new UserForm();
            user.BirthDate = new DateTime(1977, 7, 7);
            user.Countries = ConsumeInstance.Get<List<SelectListItem>>("Country");
            return View(user);
        }

        // POST: User/Create
        [AnonymousRequired]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserForm u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RegisterUser ru = new RegisterUser();
                    ru.Login = u.Login;
                    ru.Mail = u.Mail;
                    ru.BirthDate = u.BirthDate;

                    int country;
                    Int32.TryParse(u.SelectedCountry, out country);
                    ru.Country = country;

                    byte[] pwEncrypt;
                    _encrypt = new RSAEncryption(ConsumeInstance.Get<byte[]>("Auth"));
                    pwEncrypt = _encrypt.Encrypt(u.Password);
                    ru.Password = Convert.ToBase64String(pwEncrypt);

                    UserResponse ur = ConsumeInstance.PostWithReturn<RegisterUser, UserResponse >("User", ru);
                    if (ur.ErrorCode == 1)
                    {
                        FlashMessage.Warning("Email already in use");
                        return RedirectToAction("Create");
                    }
                    else if (ur.ErrorCode == 2)
                    {
                        FlashMessage.Warning("Login already in use");
                        return RedirectToAction("Create");
                    }
                    else
                        FlashMessage.Confirmation("Account created");
                    return RedirectToAction("Login");
                }
                else
                {
                    return View(u);
                }    
            }
            catch
            {
                return View();
            }
        }


        [AnonymousRequired]
        // GET: User/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: User/Create
        [AnonymousRequired]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginForm ul)
        {
            try
            {

                if (ModelState.IsValid)
                {                  
                    _encrypt = new RSAEncryption(ConsumeInstance.Get<byte[]>("Auth"));               
                    LoginUser lu = new LoginUser();
                    lu.Login = ul.Login;
                    byte[] pwEncrypt = _encrypt.Encrypt(ul.Password);
                    lu.Password = Convert.ToBase64String(pwEncrypt);

                    User u = ConsumeInstance.PostWithReturn<LoginUser, User>("User/Login", lu);

                    if (u.Login != lu.Login)
                    {
                        FlashMessage.Warning("This account doesn't exists");
                        return View(ul);
                    }
                    else if (u.IsActive == false)
                    {
                        FlashMessage.Warning("Your account has been deactivate, Please contact the admin");
                        return RedirectToAction("Contact");
                    }
                    else
                    {
                        SessionManager.Id = u.UserID;
                        SessionManager.Login = u.Login;                    
                        FlashMessage.Confirmation("Welcome " + u.Login);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return View(ul);
                }
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            SaslMechanismOAuth2 oauth2 = _googleToken.Token().Result;
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Contact", "from.website@example.com"));
            message.To.Add(new MailboxAddress("Me",_config.GetValue<string>("Google:Mail")));
            message.Subject = $"[Contact from your website] { contact.Subject }";

            BodyBuilder builder = new BodyBuilder
            {
                HtmlBody = $"<div><span style='font-weight: bold'>De</span> : {contact.Name} </div>" +
                           $"<div><span style='font-weight: bold'>Mail</span> : {contact.Email}</div>" +
                           $"<div style='margin-top: 30px'>{contact.Message}</div>"
            };

            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);

                // use the OAuth2.0 access token obtained above          
                client.Authenticate(oauth2);

                client.Send(message);
                client.Disconnect(true);
                FlashMessage.Confirmation("Mail sent with success");
                ModelState.Clear();
                return View();
            }
        }


        // GET: User/Edit
        public ActionResult Edit()
        {
            EditUser u = ConsumeInstance.Get<EditUser>("User/", SessionManager.Id);
            UserEditForm ue = new UserEditForm();
            ue.Login = u.Login;
            ue.Mail = u.Mail;
            ue.BirthDate = u.BirthDate;
            ue.SelectedCountry = u.SelectedCountry;
            ue.Countries = ConsumeInstance.Get<List<SelectListItem>>("Country");
            return View(ue);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [AuthRequired]
        public ActionResult Logout()
        {
            SessionManager.Abandon();
            return RedirectToAction("Index", "Home");
        }
       
    }
}