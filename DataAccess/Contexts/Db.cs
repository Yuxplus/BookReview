using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class Db : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Owners { get; set; }
        public DbSet<BookOwner> BookOwners { get; set; }

        public DbSet<User> Users { get; set; } // Users table

        public DbSet<Role> Roles { get; set; } // Roles table
        public DbSet<UserResource> UserResources { get; set; }

        public Db(DbContextOptions options) : base(options)
        {
            
        }
    }
}
