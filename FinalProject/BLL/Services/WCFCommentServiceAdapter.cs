using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.WCFServiceReference;
using AutoMapper;

namespace BLL.Services
{
    public class WCFCommentServiceAdapter : BLL.Interfacies.Services.IPhotoCommentService
    {
        static WCFCommentServiceClient client;

        static WCFCommentServiceAdapter()
        {
            client =  new WCFCommentServiceClient();
            Mapper.CreateMap<Interfacies.Entities.Comment, WCFServiceReference.Comment>();
            Mapper.CreateMap<WCFServiceReference.Comment, Interfacies.Entities.Comment>();
        }

        public WCFCommentServiceAdapter()
        {
        }

        public void AddComment(Interfacies.Entities.Comment comment, int photoId)
        {
            client.AddComment(Mapper.Map<WCFServiceReference.Comment>(comment), photoId);
        }

        public IEnumerable<Interfacies.Entities.Comment> GetCommentsByPhoto(int photoId)
        {
            return client.GetCommentsByPhoto(photoId).Select(x => Mapper.Map<Interfacies.Entities.Comment>(x));
        }

        public IEnumerable<Interfacies.Entities.Comment> GetLastComments(int photoId, int last)
        {
            return client.GetLastComments(photoId, last).Select(x => Mapper.Map<Interfacies.Entities.Comment>(x));
        }
    }
}
