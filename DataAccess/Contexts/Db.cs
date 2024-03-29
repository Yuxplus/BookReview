﻿using DataAccess.Entities;

namespace DataAccess.Contexts
{
    public class Db : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public Db(DbContextOptions options) : base(options)
        {
            
        }
    }
}
