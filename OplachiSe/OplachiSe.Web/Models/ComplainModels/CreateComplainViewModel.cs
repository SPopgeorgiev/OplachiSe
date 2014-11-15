namespace OplachiSe.Web.Models.ComplainModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using OplachiSe.Models;
    using OplachiSe.Web.Infrastructure.Mapping;

    public class CreateComplainViewModel : IMapFrom<Complain>
    {

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [UIHint("SingleLineText")]
        [Display(Name ="Заглавие")]
        
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(300)]
        [Display(Name ="Съдържание")]
        [UIHint("MultiLineText")]
        public string Content { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }
            
    }
}