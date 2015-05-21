using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PhotoEditModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Title { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.ImageUrl)]
        public string PhotoUrl { get; set; }
    }
}