using System;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;



namespace Birthday_Api.Models
{
    public class BirthdayContext : DbContext
    {
        public DbSet<Birthday> Birthdays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={Environment.GetEnvironmentVariable("DbPath")}");
    }
}