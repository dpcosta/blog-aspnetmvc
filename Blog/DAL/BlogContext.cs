using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Blog.DAL
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base(nameOrConnectionString:"blog")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Post> Posts { get; set; }
    }
}