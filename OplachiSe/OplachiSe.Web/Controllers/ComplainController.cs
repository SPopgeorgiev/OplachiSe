namespace OplachiSe.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using OplachiSe.Data.Contracts;
    using OplachiSe.Web.Models.ComplainModels;
    using OplachiSe.Models;
    using System.IO;
    using System;
    using System.Web;

    public class ComplainController : BaseController
    {
        public ComplainController(IOplachiSeData data)
            : base(data)
        {
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateComplainViewModel complain)
        {
            if (complain != null && ModelState.IsValid)
            {
                var newComplain = Mapper.Map<Complain>(complain);
                var user = this.Data.Users.All().Where(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
                newComplain.AuthorId = user.Id;
                newComplain.CreatedOn = DateTime.Now;
                if (complain.UploadedImage != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        complain.UploadedImage.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();

                        newComplain.Picture = new Picture
                        {
                            Content = content,
                            Extension = complain.UploadedImage.FileName.Split(new[] { '.' }).Last()
                        };
                    }
                }
                this.Data.Complains.Add(newComplain);
                this.Data.SaveChanges();
                return RedirectToAction("","Home");
            }

            return View(complain);
        }

        public ActionResult Image(int id)
        {
            var image = this.Data.Pictures.Find(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.Content, "image/" + image.Extension);
        }

        public ActionResult Details(int? id)
        {
            var complain = this.Data
                .Complains
                .All()
                .Where(c => c.Id == id).Project()
                .To<ComplainDetailsViewModel>()
                .FirstOrDefault();
                

            if (complain == null)
            {
                throw new HttpException(404, "Complain not found");
            }

            return View(complain);
        }
    }
}