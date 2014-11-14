namespace OplachiSe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Complain
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;
        private ICollection<Picture> pictures;

        public Complain()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
            this.pictures = new HashSet<Picture>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(300)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Picture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; } 
            set { this.comments = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public DateTime CreatedOn { get; set; }
    }
}
