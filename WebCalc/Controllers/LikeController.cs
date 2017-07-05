using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class LikeController : BaseController
    {
        private IUserFavoriteResultRepository UserFavoriteResult { get; set; }
        // GET: Operation

        public LikeController(IORRepository orrepository, IUserRepository UserRepository, IOperationRepository OperationRepository, ILikeRepository LikeRepository) : base(orrepository, UserRepository, OperationRepository, LikeRepository)
        {
            
        }
    }
}