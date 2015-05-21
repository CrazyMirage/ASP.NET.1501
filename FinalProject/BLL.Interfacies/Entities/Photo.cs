using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PhotoLink { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int LikesNumber { get; set; }

        public string Title { get; set; }
    }
}
