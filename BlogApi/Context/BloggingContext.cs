using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Reflection.Metadata;

namespace Api_blog.Context
{
    public class BloggingContext : DbContext
    {

        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
       
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
        }

        public DbSet<Post> Posts { get; set; }
    }
}
