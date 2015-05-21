using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVC.Infrastructure
{
    public static class PhotoExtension
    {
        public static Photo ResolveLink(this Photo photo)
        {
            if (photo == null)
                throw new ArgumentNullException();

            var directory = WebConfigurationManager.AppSettings["StoragePath"];
            photo.PhotoLink = Path.Combine(directory, photo.PhotoLink);
            return photo;
        }
    }
}