using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

        IPhotoCommentService commentService;

        public CommentController(IPhotoCommentService commentService)
        {
            this.commentService = commentService;
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(int id, string comment, int last)
        {
            if (!string.IsNullOrWhiteSpace(comment))
            {
                commentService.AddComment(new Comment()
                {
                    Author = User.Identity.Name,
                    Text = comment
                }, id);

                var comments = commentService.GetCommentsByPhoto(id, last);
                return Json(comments);
            }
            return Json(null);
        }


    }
}
