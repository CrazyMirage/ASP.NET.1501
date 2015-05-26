using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PageStatus
    {
        public int PageNumber { get; set; }
        public bool PageLast { get; set; }
        public bool PageFirst { get { return PageNumber == 1; } }
    }
}