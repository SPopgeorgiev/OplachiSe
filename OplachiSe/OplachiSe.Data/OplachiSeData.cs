namespace OplachiSe.Data
{
    using System;
    using System.Collections.Generic;

    using OplachiSe.Data.Contracts;
    using OplachiSe.Models;

    public class OplachiSeData : IOplachiSeData
    {
        private IOplachiSeDbContext context;
        private IDictionary<Type, object> repositories = new Dictionary<Type, object>();


        public OplachiSeData(IOplachiSeDbContext ctx)
        {
            this.context = ctx;
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Picture> Pictures
        {
            get { return this.GetRepository<Picture>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Complain> Complains
        {
            get { return this.GetRepository<Complain>(); }
        }

        public IRepository<Like> Likes
        {
            get { return this.GetRepository<Like>(); }
        }

        public IRepository<Vote> Votes
        {
            get { return this.GetRepository<Vote>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(GenericRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
