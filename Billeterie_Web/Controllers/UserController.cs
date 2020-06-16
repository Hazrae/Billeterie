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
            UserRegisterForm user = new UserRegisterForm();
            user.BirthDate = new DateTime(1977, 7, 7);        
            return View(user);
        }

        // POST: User/Create
        [AnonymousRequired]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRegisterForm u)
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
                        FlashMessage.Warning("Those credentials didn't match an existing user account");
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
        public IActionResult Contact(ContactViewModel contact)
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

        [AuthRequired]
        // GET: User/Edit
        public ActionResult Edit()
        {
            EditUser u = ConsumeInstance.Get<EditUser>("User/", SessionManager.Id);
            UserEditForm ue = new UserEditForm();
            ue.Login = u.Login;
            ue.Mail = u.Mail;
            ue.BirthDate = u.BirthDate;
            ue.SelectedCountry = u.SelectedCountry;      
            return View(ue);
        }

        // POST: User/Edit/5
        [AuthRequired]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEditForm user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EditUser eu = new EditUser
                    {
                        Login = user.Login,
                        Mail = user.Mail,
                        SelectedCountry = user.SelectedCountry,
                        BirthDate = user.BirthDate
                    };
                    UserResponse ur = ConsumeInstance.PutWithReturn<EditUser, UserResponse>("User/" + SessionManager.Id, eu);
                    if (ur.ErrorCode == 1)
                    {
                        FlashMessage.Warning("Email already in use");                  
                        return View(user);
                    }
                    else if (ur.ErrorCode == 2)
                    {
                        FlashMessage.Warning("Login already in use");                  
                        return View(user);
                    }
                    else
                        SessionManager.Login = user.Login;
                    FlashMessage.Confirmation("Profile updated with success");                
                    return View(user);
                }
                else
                {                
                    return View(user);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        [AuthRequired]
        public ActionResult EditPw()
        {
            return View();
        }

        // POST: User/Edit/5
        [AuthRequired]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPw(EditPasswordForm user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    byte[] pwEncrypt;
                    UserPassword up = new UserPassword();
                    _encrypt = new RSAEncryption(ConsumeInstance.Get<byte[]>("Auth"));
                    pwEncrypt = _encrypt.Encrypt(user.Password);
                    up.Password = Convert.ToBase64String(pwEncrypt);
                    pwEncrypt = _encrypt.Encrypt(user.OldPassword);
                    up.OldPassword = Convert.ToBase64String(pwEncrypt);

                    UserResponse ur = ConsumeInstance.PutWithReturn<UserPassword, UserResponse>("User/ChangePw/" + SessionManager.Id, up);
                    if (ur.ErrorCode == 3)
                    {
                        FlashMessage.Warning("The old password doesn't match");
                        return View(user);
                    }
                    else
                        FlashMessage.Confirmation("Password Changed, Please reconnect");
                    SessionManager.Abandon();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(user);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Cart()
        {              
            CheckoutViewModel CVM = new CheckoutViewModel(SessionManager,ConsumeInstance);
            SessionManager.CB_Num = CVM.user.CB_Num;
            return View(CVM);
        }   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cart([FromForm]CheckoutViewModel CVM)
        {
            if (CVM.user.CB_Num_Enter!= SessionManager.CB_Num.ToString())
            {
                UserCard uc = new UserCard
                {
                    UserID = SessionManager.Id,
                    CB_Num = long.Parse(CVM.user.CB_Num_Enter),
                    CB_Valid = new DateTime(1900, int.Parse(CVM.user.CB_Valid_Enter.Substring(0,2)), int.Parse(CVM.user.CB_Valid_Enter.Substring(2, 2)))             
                };

                ConsumeInstance.Post<UserCard>("User/AddCard",uc);
            }
            FlashMessage.Confirmation("Purchase Confirmed - Tickets sent by mail");
            return RedirectToAction("Index","Home");
        }   


        [AuthRequired]
        public ActionResult Logout()
        {
            SessionManager.Abandon();
            return RedirectToAction("Index", "Home");
        }
       
    }
}