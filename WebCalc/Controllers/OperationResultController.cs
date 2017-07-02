using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class OperationResultController : Controller
    {
        private IOperationResultRepository OperationResultRepository { get; set; }
        // GET: Operation

        public OperationResultController()
        {
            OperationResultRepository = new OperationResultRepository();
        }

        public ActionResult Index()
        {
            ViewBag.OperationResults = OperationResultRepository.GetAll();
            return View();
        }
    }
}