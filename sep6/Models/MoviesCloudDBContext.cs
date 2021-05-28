using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Movies_sep6.Models
{
    public class MoviesCloudDBContext : DbContext
    {
        public DbSet<MoviesCloud> MoviesFromCloud { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server=34.136.229.1;database=Movies;user=root;password=Sep6_1234");
        }
    }
}