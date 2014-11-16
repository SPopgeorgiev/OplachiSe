namespace OplachiSe.Web.Models.CommentModels
{
    using System.ComponentModel.DataAnnotations;

    using OplachiSe.Models;
    using OplachiSe.Web.Infrastructure.Mapping;

    public class AddCommentViewModel : IMapFrom<Comment>
    {
        [Required]
        [MinLength(5)]
        [MaxLength(150)]
        [Display(Name = "Коментар")]
        [UIHint("CommentText")]
        public string Content { get; set; }

        public int ComplainId { get; set; }
    }
}