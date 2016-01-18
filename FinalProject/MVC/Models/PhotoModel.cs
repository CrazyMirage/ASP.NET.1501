using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PhotoModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PhotoLink { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int LikesNumber { get; set; }

        public string Title { get; set; }

        public bool Like { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}