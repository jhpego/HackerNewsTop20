using BestHackerNews.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestHackerNews.Data
{
    public class MainContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=yourStrong(!)Password;Persist Security Info=True;User ID=sa;Initial Catalog=hackernews_db;Data Source=localhost");
        }


        public DbSet<Item> NewsItems { get; set; }


    }
}
