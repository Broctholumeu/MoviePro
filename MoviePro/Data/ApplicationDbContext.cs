using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MoviePro.Models;

namespace MoviePro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MoviePro.Models.Movie> Movie { get; set; }
        public DbSet<MoviePro.Models.Movie> Cast { get; set; }
        public DbSet<MoviePro.Models.Cast> Cast_1 { get; set; }
        public DbSet<MoviePro.Models.Crew> Crew { get; set; }
    }
}
