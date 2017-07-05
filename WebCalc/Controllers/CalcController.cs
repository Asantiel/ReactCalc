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
        private IUserRepository UserRepository { get; set; }
        private IOperationRepository OperationRepository { get; set; }

        public CalcController(IORRepository orrepository, 
            IUserRepository UserRepository, 
            IOperationRepository OperationRepository)
        {
            Calc = new Calc();
            ORRepository = orrepository;
            this.UserRepository = UserRepository;
            this.OperationRepository = OperationRepository;
        }

        public ActionResult Index()
        {
            var model = new CalcModel();
            ViewBag.Operations = new SelectList(OperationRepository.GetAll(), "Name", "FullName");
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CalcModel model)
        {
            ViewBag.Operations = new SelectList(OperationRepository.GetAll(), "Name", "FullName");
            var operation = Calc.Operations.FirstOrDefault(o => o.Name == model.Operation);
            var operID = OperationRepository.GetByName(operation.Name).Id;
            if (operation != null)
            {
                var inputData = string.Join(",", model.Arguments);

                var OldResult = ORRepository.GetOldResult(operID, inputData);
                if (!double.IsNaN(OldResult))
                {
                    if (model.IsCompute)
                    {
                        // пересчитываем и присваеваем в model.Result
                        OldResult = operation.Execute(model.Arguments);
                        // находим польхователя и по входным данным и id операции ищем запись в ORRepository
                        var currUserId = UserRepository.GetByName(User.Identity.Name).Id; 
                        var t = ORRepository.GetRecord(currUserId, operID, inputData);
                        // передаем изменения в ORRepository
                        t.Result = OldResult;
                        ORRepository.Update(t);
                    }
                    model.Result = OldResult;
                }
                else
                {
                    model.Result = operation.Execute(model.Arguments);
                    
                    var rec = ORRepository.Create();
                    var currUser = UserRepository.GetByName(User.Identity.Name);
                    rec.OperationId = OperationRepository.GetByName(operation.Name).Id;
                    rec.AuthorId = currUser.Id;
                    rec.ExecutionDate = DateTime.Now;
                    rec.ExecutionTime = new Random().Next(0, 100);
                    rec.InputData = inputData;
                    rec.Result = model.Result ?? Double.NaN;

                    ORRepository.Update(rec);
                }
            }
            return View(model);
        }


    }
}