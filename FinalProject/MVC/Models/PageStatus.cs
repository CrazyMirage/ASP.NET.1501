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
        public int PageNext { get { return PageLast ? PageNumber : PageNumber + 1; } }
        public int PagePrevious { get { return PageFirst ? PageNumber : PageNumber - 1; } }
    }
}