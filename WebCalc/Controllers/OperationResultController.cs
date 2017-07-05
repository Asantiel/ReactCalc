using DomainModels.EF;
using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class OperationResultController : BaseController
    {
        public OperationResultController(IORRepository orrepository, IUserRepository UserRepository, IOperationRepository OperationRepository, ILikeRepository LikeRepository) : base(orrepository, UserRepository, OperationRepository, LikeRepository)
        {
        }

        public ActionResult Index()
        {
            var currUser = GetCurrentUser();

            var results = ORRepository.GetByUser(UserRepository.GetByName(User.Identity.Name));
            var likes = LikeRepository.GetAll()     //получаем все лайки
                .Where(u=>u.UserID == currUser.Id)  //фильтруем по текущему юзеру
                .Select(it => it.ResultID);           //достаём из лайков результаты операций

            foreach (var result in results)
            {
                result.IsLiked = likes.Contains(result.Id);
            }

            return View(results);
        }

        [HttpPost]
        public JsonResult Like(long id)
        {
            var result = ORRepository.Get(id);
            if (result == null)
            {
                return Json(new {Success = false, Error= "Не удалось найти результат" });
            }


            var currUser = UserRepository.GetByName(User.Identity.Name);

            var like = LikeRepository.GetAll()
                .FirstOrDefault(it => it.UserID == currUser.Id && it.ResultID == id);

            if (like != null)
            {
                LikeRepository.Delete(like);
                return Json(new { Success = true, Name = "Like", Id = like.Id });
            }

            like = LikeRepository.Create();
            like.UserID = currUser.Id;
            like.ResultID = result.Id;

            LikeRepository.Update(like);

            return Json(new { Success = true, Name = "DisLike", Id = like.Id });
        }
    }
}