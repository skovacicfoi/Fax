using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class FaxDbContext : IdentityDbContext<User>
    {
        public FaxDbContext(DbContextOptions<FaxDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //sasaass
            optionsBuilder.UseSqlServer(
                    "Server = (localdb)\\mssqllocaldb;" +
            "Database = Faksistent;" +
            "Trusted_Connection = true;");
        }
    }
}
