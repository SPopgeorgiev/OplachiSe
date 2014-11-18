namespace OplachiSe.Web.Models.ComplainModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using OplachiSe.Models;
    using OplachiSe.Web.Infrastructure.Mapping;

    public class CreateComplainViewModel : IMapFrom<Complain>
    {
        public CreateComplainViewModel()
        {
        }
        
        [Required(ErrorMessage = "Полето е задължително")]
        [MinLength(3, ErrorMessage = "Полето трябва да е между 3 и 40 символа")]
        [MaxLength(40, ErrorMessage = "Полето трябва да е между 3 и 40 символа")]
        [UIHint("SingleLineText")]
        [Display(Name ="Заглавие")]
        
        public string Title { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [MinLength(20, ErrorMessage = "Полето трябва да е между 2 и 300 символа")]
        [MaxLength(300, ErrorMessage = "Полето трябва да е между 2 и 300 символа")]
        [Display(Name ="Съдържание")]
        [UIHint("MultiLineText")]
        public string Content { get; set; }

        [Display(Name = "Категория")]
        [UIHint("DropDownList")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }
            
    }
}