namespace OplachiSe.Data.Contracts
{
    using OplachiSe.Models;

    public interface IOplachiSeData
    {
        IRepository<User> Users { get; }

        IRepository<Picture> Pictures { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Complain> Complains { get; }

        IRepository<Like> Likes { get; }

        IRepository<Vote> Votes { get; }

        int SaveChanges();
    }
}
