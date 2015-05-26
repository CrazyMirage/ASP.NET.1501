using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Filters
{
    public class GlobalExceptionCather : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled)
            {
                exceptionContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {{ "Controller", "Error" },
                                      { "Action", "UnexpectedError" } });
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}