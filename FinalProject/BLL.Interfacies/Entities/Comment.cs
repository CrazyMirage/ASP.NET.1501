﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string  Author { get; set; }
        
        public string Text { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? ParentComment { get; set; }
    }
}
