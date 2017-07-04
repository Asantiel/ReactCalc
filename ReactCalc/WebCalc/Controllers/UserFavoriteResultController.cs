using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class UserFavoriteResultController : Controller
    {
        private IUserFavoriteResultRepository UserFavoriteResult { get; set; }
        // GET: Operation

        public UserFavoriteResultController()
        {
            UserFavoriteResult = new UserFavoriteResultRepository();
        }

        public ActionResult Index()
        {
            ViewBag.UserFavoriteResult = UserFavoriteResult.GetAll();
            return View();
        }
    }
}