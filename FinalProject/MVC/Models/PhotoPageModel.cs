using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PhotoPageModel
    {
        public PageStatus PageStatus { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
    }
}