using JournalAppAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        //public DbSet<AppUser> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }    
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<News>()
                .HasOne(n => n.Photo).WithOne(p => p.News).HasForeignKey<Photo>(p => p.NewsId);

            builder.Entity<News>()
                .HasMany(n => n.Comments)
                .WithOne(c => c.News)
                .HasForeignKey(k => k.NewsId);

            builder.Entity<AppUser>(b =>
            {
                b.Property(u => u.UserName).HasMaxLength(30);
                b.Property(u => u.UserName).IsUnicode(true);
            });

            builder.Entity<AppUser>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(k => k.AuthorId);

            builder.Entity<News>()
                .HasOne(u => u.Author)
                .WithMany(n => n.News)
                .HasForeignKey(k => k.AuthorId);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(x => new { x.UserId, x.RoleId });

                userRole.HasOne(x => x.Role).WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId).IsRequired();

                userRole.HasOne(x => x.User).WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId).IsRequired();
            });
        }
    }
}
