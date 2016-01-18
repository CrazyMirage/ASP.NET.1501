using BLL.Interfacies.Services;
using MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class LikeController : Controller
    {
        //
        // GET: /Like/
        
        IPhotoLikeService likeService;
        IPhotoService photoService;

        public LikeController(IPhotoService photoService, IPhotoLikeService likeService)
        {
            this.photoService = photoService;
            this.likeService = likeService;
        }

        [Authorize]
        [HttpPost]
        public ActionResult LikeResolve(int id, Status status)
        {
            if (status == Status.Like)
                return Like(id);
            else if (status == Status.Dislike)
                return Dislike(id);
            return null;
        }


        private ActionResult Like(int id)
        {
            likeService.AddLike(User.Identity.Name, id);
            var likesNumber = likeService.NumberOfLikes(id);

            return Json(likesNumber);
        }


        private ActionResult Dislike(int id)
        {
            likeService.RemoveLike(User.Identity.Name, id);
            var likesNumber = likeService.NumberOfLikes(id);

            return Json(likesNumber);

        }

        [ChildActionOnly]
        public ActionResult LikeButton(bool status)
        {
            return PartialView(status);
        }
    }
}
