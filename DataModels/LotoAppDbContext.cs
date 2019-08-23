using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DataModels
{
    public class LotoAppDbContext : DbContext
    {
        public LotoAppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<UserDbo> Users{ get; set; }
        public DbSet<WinnerDbo> Winners { get; set; }
        public DbSet<TicketDbo> Tickets { get; set; }
        public DbSet<DrawDbo> Draws { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(
                Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            builder.Entity<UserDbo>()
               .HasData(
               new UserDbo()
               {
                   Id = 1,
                   FirstName = "Bob",
                   LastName = "Bobsky",
                   UserName = "bob007",
                   Password = hashedPassword,
                   IsAdmin = true,
                   Address = "Partizanska 33"
               });
        }
    }
}
