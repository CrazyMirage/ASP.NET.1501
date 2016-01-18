using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Entities
{
    public class Like
    {
        public int Id { get; set; }

        public int PhotoId { get; set; }

        public string User { get; set; }
    }
}
