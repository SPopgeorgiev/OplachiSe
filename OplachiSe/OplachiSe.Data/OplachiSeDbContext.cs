namespace OplachiSe.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using OplachiSe.Models;

    public class OplachiSeDbContext : IdentityDbContext<User>
    {
        public OplachiSeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static OplachiSeDbContext Create()
        {
            return new OplachiSeDbContext();
        }
    }
}
