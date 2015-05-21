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

        IPhotoService photoService;

        public PhotoController(IPhotoService service)
        {
            photoService = service;
        }

        public ActionResult Index()
        {
            return View();
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

            }
            if (!string.Equals(photo.UserName, User.Identity.Name, StringComparison.InvariantCultureIgnoreCase))
            {

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

            }
            if (!string.Equals(photo.UserName, User.Identity.Name, StringComparison.InvariantCultureIgnoreCase))
            {

            }
            photoService.EditDescription(model.Id, model.Title);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            var photo = photoService.GetPhoto(id);
            photo.ResolveLink();
            return View(photo);
        }
    }
}
