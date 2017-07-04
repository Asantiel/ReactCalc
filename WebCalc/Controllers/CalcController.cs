using DomainModels.EF;
using DomainModels.Repository;
using ReactCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {
        private Calc Calc { get; set; }

        private IORRepository ORRepository { get; set; }

        private IUserRepository userrep { get; set; }

        public CalcController(IORRepository orrepository, IUserRepository userrep)
        {
            Calc = new Calc();
            ORRepository = orrepository;
            this.userrep = userrep;
        }

        public ActionResult Index()
        {
            var model = new CalcModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CalcModel model)
        {
            var operation = Calc.Operations.FirstOrDefault(o => o.Name == model.Operation);
            if (operation != null)
            {

                if (operation != null)
                {
                    var operId = 2;
                    var inputData = string.Join(",", model.Arguments);

                    var OldResult = ORRepository.GetOldResult(operId, inputData);
                    if (!double.IsNaN(OldResult))
                    {
                        model.Result = OldResult;
                    }
                    else
                    {
                        model.Result = operation.Execute(model.Arguments);

                        var rec = ORRepository.Create(null);
                        var currUser = userrep.GetByName(User.Identity.Name);
                        rec.AuthorId = currUser.Id;

                        //ХАК
                        rec.OperationId = operId;

                        rec.ExecutionDate = DateTime.Now;
                        rec.ExecutionTime = new Random().Next(0, 100);
                        rec.InputData = string.Join(",", model.Arguments);
                        rec.Result = model.Result ?? Double.NaN;

                        ORRepository.Update(rec);
                    }
                }
                return View(model);
            }

            return View();
        }
    }
}