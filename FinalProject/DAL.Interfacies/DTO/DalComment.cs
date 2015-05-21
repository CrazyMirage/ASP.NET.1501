﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfacies.DTO
{
    public class DalComment : IEntity
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }

        public int PhotoId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? ParentComment { get; set; }
    }
}
