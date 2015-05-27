using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MVC.Models
{
    public class PhotoPageModel
    {
        public PageStatus PageStatus { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
        public ActionDestination DefaultDestination { get; set; }
        public object ExtraValues { get; set; }
    }
}