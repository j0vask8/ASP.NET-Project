using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ForumContext();

            context.Users.Add(new User
            {
                Username = "Mira",
                Email = "mira@gmail.com",
                Password = "Mira",
                RoleId = 3,
            });

            context.SaveChanges();

            //context.Users.Add(new User
            //{
            //    Username = "Jovan",
            //    Email = "jovan@gmail.com",
            //    Password = "Jovan",
            //});

            //var context = new ForumContext();
            //var users = context
            //    .Users
            //    .Where(u => u.Username.Length > 3)
            //    .Include(u => u.Role).ToList();

            //foreach (var user in users)
            //{
            //    System.Console.WriteLine(user.Username + " " + user.Role.Name);
            //}
        }
    }
}