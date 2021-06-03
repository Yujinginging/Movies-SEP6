using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sep6.Models
{
    public class MoviesCloudDBContext : DbContext
    {
        public DbSet<MoviesCloud> MoviesCloud { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseMySQL("server=34.136.229.1;database=Movies;user=root;port=3306;password=Sep6_1234");
            options.UseMySQL("Server=moviescloud.mysql.database.azure.com; Port=3306; Database=mysql_movie; Uid=sep6@moviescloud; Pwd=Movies123456; SslMode=Preferred;");
            //options.UseMySQL("server=127.0.0.1;database=movies;user=root;password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<MoviesCloud>()
                .HasKey(f => new { f.Ratings, f.Votings, f.Stars });
            modelBuilder.Entity<MoviesCloud>()
                .Property(f => f.Ratings).HasColumnName("Rating");
*/
        }
    }
}
