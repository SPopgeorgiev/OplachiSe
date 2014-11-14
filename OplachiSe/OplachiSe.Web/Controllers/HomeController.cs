namespace OplachiSe.Web.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using OplachiSe.Data.Contracts;
    using OplachiSe.Web.Models;

    public class HomeController : BaseController
    {
        public HomeController(IOplachiSeData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var complains = this.Data
                .Complains
                .All()
                .Project()
                .To<ComplainViewModel>()
                .ToList();

            return View(complains);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}