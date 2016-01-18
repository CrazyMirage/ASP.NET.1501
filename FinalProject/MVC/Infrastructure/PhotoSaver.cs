using BLL.Interfacies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVC.Infrastructure
{
    public class PhotoSaver : IFileSaver
    {

        private HttpPostedFileBase photo;
        private string destination;

        public PhotoSaver(HttpPostedFileBase photo, string destination)
        {
            this.photo = photo;
            this.destination = destination;
        }

        public string FileName
        {
            get { return photo.FileName; }
        }

        public void Save(string path)
        {
            var fullPath = Path.Combine(destination, path);
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            }
            photo.SaveAs(Path.Combine(destination, path));
        }
    }
}