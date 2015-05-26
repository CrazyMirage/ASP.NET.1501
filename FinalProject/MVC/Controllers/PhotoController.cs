using BLL.Interfacies.Services;
using MVC.Infrastructure;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PhotoController : Controller
    {
        //
        // GET: /Photo/

        IPhotoLikeService likeService;
        IPhotoService photoService;
        IPhotoCommentService commentService;


        public PhotoController(IPhotoService photoService, IPhotoLikeService likeService, IPhotoCommentService commentService)
        {
            this.photoService = photoService;
            this.likeService = likeService;
            this.commentService = commentService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddPhoto()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddPhoto(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return RedirectToAction("FileNotSelected", "Error");
            }
            var photo = photoService.AddPhoto(new PhotoSaver(file, Server.MapPath(WebConfigurationManager.AppSettings["StoragePath"])), User.Identity.Name);
            return View("Edit",new PhotoEditModel() { Id = photo.Id, PhotoUrl = photo.ResolveLink().PhotoLink });
        }
        
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var photo = photoService.GetPhoto(id);
            if (photo == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            if (!string.Equals(photo.UserName, User.Identity.Name, StringComparison.InvariantCultureIgnoreCase))
            {
                return RedirectToAction("WrongPermission", "Error");
            }
            return View(new PhotoEditModel() { Id = photo.Id, PhotoUrl = photo.ResolveLink().PhotoLink});
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(PhotoEditModel model)
        {
            var photo = photoService.GetPhoto(model.Id);
            if (photo == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            if (!string.Equals(photo.UserName, User.Identity.Name, StringComparison.InvariantCultureIgnoreCase))
            {
                return RedirectToAction("WrongPermission", "Error");
            }
            photoService.EditDescription(model.Id, model.Title);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            var photo = photoService.GetPhoto(id);
            photo.ResolveLink();

            return View(new PhotoModel() { Id = photo.Id,
                UserName = photo.UserName,
                CreatedDateTime = photo.CreatedDateTime,
                PhotoLink = photo.PhotoLink,
                LikesNumber = photo.LikesNumber,
                Title = photo.Title,
                Like = User.Identity.IsAuthenticated ? likeService.VerifyLikeAbility(User.Identity.Name, id) : false,
                Comments = commentService.GetCommentsByPhoto(id)
            });   
        }

        public ActionResult Page(int page)
        {
            ViewBag.Page = page;
            return View(page);
        }

        [ChildActionOnly]
        public ActionResult PhotoPage(int page)
        {
            int photosOnPage = 12;
            int requestSize;
            var photos = photoService.GetPhotos(photosOnPage, page, out requestSize);

            var model = new PhotoPageModel()
            {
                Photos = photos.Select(x => x.ResolveLink()),
                PageStatus = new PageStatus { PageNumber = page, PageLast = requestSize - (page * photosOnPage) <= 0 }
            };

            return PartialView("_PhotoPage", model);
        }
    }
}
