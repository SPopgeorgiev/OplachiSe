namespace OplachiSe.Web.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using OplachiSe.Data.Contracts;
    using OplachiSe.Web.Models;
    using OplachiSe.Web.Models.ComplainModels;

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
                .Take(3)
                .Project()
                .To<ComplainViewModel>()
                .ToList();
                
            return View(complains);
        }

        [ChildActionOnly]
        public ActionResult GetLatestComplains()
        {
            var latestComplains = this.Data
                .Complains
                .All()
                .OrderByDescending(c => c.CreatedOn)
                .Take(10)
                .Project()
                .To<LatestComplainViewModel>()
                .ToList();

            return PartialView("_LatestComplainsPartial", latestComplains);
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