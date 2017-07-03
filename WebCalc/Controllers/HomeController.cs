using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public HomeController()
        {
            UserRepository = new DomainModels.EF.UserRepository();
        }

        public ActionResult Index()
        {
            ViewBag.Users = UserRepository.GetAll();
            return View();
        }

        public ActionResult View(long id)
        {
            return View(UserRepository.Get(id));
        }
    }
}