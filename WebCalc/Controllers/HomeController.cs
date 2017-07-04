using DomainModels.Models;
using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public HomeController(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Login,Password,FIO")] User user)
        {
            UserRepository.Create(user);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            UserRepository.Delete(UserRepository.Get(id));
            return RedirectToAction("Index");
        }

        public ActionResult Update(long id)
        {
            var User = UserRepository.Get(id);
            return View("Create");
        }

        [HttpPost]
        public ActionResult Update([Bind(Include = "Login,Password,FIO")] User user)
        {
            UserRepository.Update(user);
            return RedirectToAction("Index");
        }
    }
}