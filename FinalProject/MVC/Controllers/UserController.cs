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
    public class UserController : Controller
    {
        //
        // GET: /User/
        
        IPhotoService photoService;


        public UserController(IPhotoService photoService)
        {
            this.photoService = photoService;
        }


        public ActionResult User(string user)
        {
            ViewBag.User = user;
            ViewBag.Page = 1;
            return View("UserPage");
        }

        public ActionResult Page(string user, int page)
        {
            ViewBag.User = user;
            ViewBag.Page = page;
            return View("UserPage");
        }
        
        [ChildActionOnly]
        public ActionResult PhotoPage(int page, string user)
        {
            int requestSize;
            int photosOnPage = int.Parse(WebConfigurationManager.AppSettings["PhotosOnPage"]);
            var photos = photoService.GetPhotosByUser(user, photosOnPage, page, out requestSize);

            var model = new PhotoPageModel()
            {
                Photos = photos.Select(x => x.ResolveLink()),
                PageStatus = new PageStatus { PageNumber = page, PageLast = requestSize - (page * photosOnPage) <= 0 },
                DefaultDestination = new ActionDestination(){Action = "Page", Controller = "User"}
            };

            return PartialView("_PhotoPage", model);
        }
    }
}
