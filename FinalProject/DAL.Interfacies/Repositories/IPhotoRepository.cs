using DAL.Interfacies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfacies.Repositories
{
    public interface IPhotoRepository : IUserConnectedRepository<DalPhoto>
    {
        void EditDescription(int id, string description);
        void AddLike(int id);
        void RemoveLike(int id);
    }
}
