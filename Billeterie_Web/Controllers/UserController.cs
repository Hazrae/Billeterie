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

namespace Billeterie_Web.Controllers
{
    public class UserController : BaseController
    {
        private IRSAEncryption _encrypt;
        public UserController(IAPIConsume apiConsume, IFlashMessage flash) : base(apiConsume, flash)
        {

        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            UserForm user = new UserForm();
            user.BirthDate = new DateTime(1977, 7, 7);
            user.Countries = ConsumeInstance.Get<List<SelectListItem>>("Country");
            return View(user);
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}