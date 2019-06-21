using Domain;
using EfDataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess
{
    public class ForumContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4AMA0A1\SQLEXPRESS;Initial Catalog=Sajt;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());

            //modelBuilder.Entity<Role>().HasData(new Role
            //{
            //    Name = "Admin"
            //});

            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Username = "Perica",
            //});

            //modelBuilder.Entity<Role>().HasData(new Role
            //{
            //    Name = "User"
            //});

            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Username = "Jova",
            //});

            //modelBuilder.Entity<Category>().HasData(new Category
            //{
            //    Id = 1,
            //    Name = "Sport"
            //});
        }
    }
}
