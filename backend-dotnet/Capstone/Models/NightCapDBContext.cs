using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class NightCapDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");
        }

        public DbSet<Forum> Forums { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Moderator> Moderators { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<UpdatedComment> UpdatedComments { get; set; }

        public DbSet<UpdatedPost> UpdatedPosts { get; set; }

        public DbSet<FavoriteForum> FavoriteForums { get; set; }

    }
}
