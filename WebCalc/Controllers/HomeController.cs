using DomainModels.Models;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Login,Password,FIO")] User user)
        {
            user.Uid = Guid.NewGuid();
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
            return View("Create");
        }

        [HttpPost]
        public ActionResult Update([Bind(Include = "Login,Password,FIO")] User user, Guid uid)
        {
            UserRepository.Update(user, uid);
            return RedirectToAction("Index");
        }
    }
}