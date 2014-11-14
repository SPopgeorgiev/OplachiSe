namespace OplachiSe.Web.Controllers
{
    using System.Web.Mvc;

    using OplachiSe.Data.Contracts;
    using OplachiSe.Models;

    public class BaseController : Controller
    {
        public BaseController(IOplachiSeData data)
        {
            this.Data = data;
        }
        
        protected IOplachiSeData Data { get; set; }

        protected User CurrentUser{ get; set; }
    }
}