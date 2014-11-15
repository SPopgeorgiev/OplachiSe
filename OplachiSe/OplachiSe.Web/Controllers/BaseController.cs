namespace OplachiSe.Web.Controllers
{
    using System;
    using System.Web.Routing;
    using System.Web.Mvc;
    using System.Linq;

    using OplachiSe.Data.Contracts;
    using OplachiSe.Models;

    public class BaseController : Controller
    {
        public BaseController(IOplachiSeData data)
        {
            this.Data = data;
        }
        
        protected IOplachiSeData Data { get; set; }

        protected User UserProfile { get; set; }
    }
}