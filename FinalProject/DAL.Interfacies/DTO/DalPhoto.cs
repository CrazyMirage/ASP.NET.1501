using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfacies.DTO
{
    public class DalPhoto : IEntity
    {
        public int Id { get; set; }
        public string Author { get; set; }
        //public int UserId { get; set; }
        public string PhotoLink { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int LikesNumber { get; set; }

        public string Title { get; set; }
    }
}
