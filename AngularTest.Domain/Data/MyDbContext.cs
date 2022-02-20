using System.Collections.Generic;
using AngularTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularTest.Domain.Data
{
    public class MyDbContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                OpsBuilder = new DbContextOptionsBuilder<MyDbContext>();
                OpsBuilder.UseSqlServer(settings.SqlConnectionString);
                dbOptions = OpsBuilder.Options;
            }
            public DbContextOptionsBuilder<MyDbContext> OpsBuilder { get; set; }
            public DbContextOptions<MyDbContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }
        public static OptionsBuild ops = new OptionsBuild();

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>()
                .HasData(new List<Post>()
                {
                    new Post{PostId = 1, Title = "title1", Text = "text1"},
                    new Post{PostId = 2, Title = "title2", Text = "text2"},
                    new Post{PostId = 3, Title = "title3", Text = "text3"},
                });
        }

        public DbSet<Post> Posts { get; set; }
    }
}