using BLL.Interfacies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Infrastructure;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        IPhotoService photoService;

        public HomeController(IPhotoService service)
        {
            photoService = service;
        }

        public ActionResult Index()
        {
            var photos = photoService.GetPhotos(40, 1);
            return View("Index2", photos.Select(x => x.ResolveLink()));
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            return PartialView();
        }
    }
}
