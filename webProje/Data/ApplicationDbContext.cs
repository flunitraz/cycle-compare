using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using webProje.Models;

namespace webProje.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bisiklet> Bisikletler { get; set; }
        public DbSet<KullaniciFavori> KullaniciFavorileri { get; set; }
        public DbSet<Karsilastirma> Karsilastirmalar { get; set; }
    }
}
