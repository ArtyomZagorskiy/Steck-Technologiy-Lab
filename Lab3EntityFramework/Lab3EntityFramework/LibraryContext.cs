using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lab3EntityFramework
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> libraryBooks { get; set; }
        public DbSet<Reader> readers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=librarydb;Trusted_Connection=True;MultipleActiveResultSets=True").UseLazyLoadingProxies(); ;
        }

    }
}
