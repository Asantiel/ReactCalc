using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class OperationController : Controller
    {
        private IOperationRepository OperationRepository { get; set; }
        // GET: Operation

        public OperationController(IOperationRepository OperationRepository)
        {
            this.OperationRepository = OperationRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Operations = OperationRepository.GetAll();
            return View();
        }
    }
}