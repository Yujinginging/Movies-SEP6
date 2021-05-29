using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using sep6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sep6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesCloudController : Controller
    {
       
        //1.GET: MoviesCloud/GetTopTenMoviesByRatings
        [HttpGet("[action]")]
        public List<string> GetTopTenMoviesByRatings()
        {
            var context = new MoviesCloudDBContext();
            return context.MoviesCloud.OrderBy(i => i.Ratings).Select(f => f.Name).Take(10).ToList();
        }

        //2.GET: MoviesCloud/GetTopTenMoviesByVotes
        [HttpGet("[action]")]
        public List<string> GetTopTenMoviesByVotes()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.OrderBy(i => i.Votings).Select(f => f.Name).Take(10).ToList();
        }

        //3.GET: MoviesCloud/GetTopTenMoviesByStars
        [HttpGet("[action]")]
        public List<string> GetTopTenMoviesByStars()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.OrderBy(i => i.Stars).Select(f => f.Name).Take(10).ToList();
        }

        //4.GET: MoviesCloud/GetRatings
        [HttpGet("[action]")]
        public List<float> GetRatings()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.Select(f => f.Ratings).ToList();
        }

        //5.GET:MoviesCloud/GetMoviesNames
        [HttpGet("[action]")]
        public List<string> GetMoviesNames()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.Select(f => f.Name).ToList(); 
        }
        //6.GET:MoviesCloud/GetVotes
        [HttpGet("[action]")]
        public List<float> GetVotes()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.Select(f => f.Votings).ToList(); 
        }
        //7.GET:MoviesCloud/GetStars
        [HttpGet("[action]")]
        public List<float> GetStars()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.Select(f => f.Stars).ToList(); 
        }

       
        //9.GET:MoviesCloud/GetMeanOfRatings
        [HttpGet("[action]")]
        public double GetMeanOfRatings()
        {
            var context = new MoviesCloudDBContext();

            var ratings = context.MoviesCloud.Select(f => f.Ratings).ToList().Average();
            
            return ratings;
        }

        //9.GET:MoviesCloud/GetMeanOfVotes
        [HttpGet("[action]")]
        public double GetMeanOfVotes()
        {
            var context = new MoviesCloudDBContext();

            var votes = context.MoviesCloud.Select(f => f.Votings).ToList().Average();
           
            return votes;
        }
        //9.GET:MoviesCloud/GetMeanOfStars
        [HttpGet("[action]")]
        public double GetMeanOfStars()
        {
            var context = new MoviesCloudDBContext();

            var stars = context.MoviesCloud.Select(f => f.Stars).ToList().Average();
            
            return stars;
        }

        //10.GET:MoviesCloud/GetMeanRatingByTimePeriod/?StartYear=&EndYear=
        [HttpGet("[action]")]
        public double GetMeanRatingByTimePeriod(int startYear, int endYear)
        {
            var context = new MoviesCloudDBContext();
            var ratings = context.MoviesCloud.Where(f => f.Year >= startYear && f.Year <= endYear).Select(f=>f.Ratings).ToList().Average();
           
            return ratings;
        }

        //11.GET:MoviesCloud/GetMovieNamesByTimePeriod/?StartYear=&EndYear=
        [HttpGet("[action]")]
        public List<string> GetMovieNamesByTimePeriod(int startYear, int endYear)
        {
            var context = new MoviesCloudDBContext();
            return context.MoviesCloud.Where(f => f.Year >= startYear && f.Year <= endYear).OrderBy(i=>i.Name).Select(f => f.Name).ToList();
           
        }

        //12.GET:MoviesCloud/GetMovieRatingsByTimePeriod/?StartYear=&EndYear=
        [HttpGet("[action]")]
        public List<float> GetMovieRatingsByTimePeriod(int startYear, int endYear)
        {
            var context = new MoviesCloudDBContext();
            return context.MoviesCloud.Where(f => f.Year >= startYear && f.Year <= endYear).OrderBy(i => i.Name).Select(f => f.Ratings).ToList();
            

        }

    }
}
