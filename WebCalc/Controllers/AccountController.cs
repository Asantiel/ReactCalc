using DomainModels.Models;
using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebCalc.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public AccountController(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Name, string Password)
        {
            // поиск пользователя в бд
            if (UserRepository.IsValid(Name, Password))
            {
                FormsAuthentication.SetAuthCookie(Name, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}