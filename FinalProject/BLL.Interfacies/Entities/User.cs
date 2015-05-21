using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Entities
{
    public class  User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public int RoleId { get; set; } 
    }
}
