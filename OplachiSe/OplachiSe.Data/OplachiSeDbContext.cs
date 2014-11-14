namespace OplachiSe.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using OplachiSe.Models;
    using OplachiSe.Data.Contracts;

    public class OplachiSeDbContext : IdentityDbContext<User>
    {
        public OplachiSeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Complain> Complains { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Picture> Pictures { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public static OplachiSeDbContext Create()
        {
            return new OplachiSeDbContext();
        }
    }
}
