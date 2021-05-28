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

        //
        [HttpGet("[action]")]
        public List<MoviesCloud> GetAllMovies()
        {
            var context = new MoviesCloudDBContext();


            return context.MoviesCloud.ToList();
        }

        //9.GET:MoviesCloud/GetMeanOfRatings
        [HttpGet("[action]")]
        public double GetMeanOfRatings()
        {
            var context = new MoviesCloudDBContext();

            var ratings = context.MoviesCloud.Select(f => f.Ratings).ToList();
            var sum = 0;
            for(int i = 0; i < ratings.Count(); i++)
            {
                sum = (int)(sum + ratings[i]);
            }
            var average = (double)(sum / ratings.Count());
            return average;
        }

        //9.GET:MoviesCloud/GetMeanOfVotes
        [HttpGet("[action]")]
        public double GetMeanOfVotes()
        {
            var context = new MoviesCloudDBContext();

            var votes = context.MoviesCloud.Select(f => f.Votings).ToList();
            var sum = 0;
            for (int i = 0; i < votes.Count(); i++)
            {
                sum = (int)(sum + votes[i]);
            }
            var average = (double)(sum / votes.Count());
            return average;
        }
        //9.GET:MoviesCloud/GetMeanOfStars
        [HttpGet("[action]")]
        public double GetMeanOfStars()
        {
            var context = new MoviesCloudDBContext();

            var stars = context.MoviesCloud.Select(f => f.Stars).ToList();
            var sum = 0;
            for (int i = 0; i < stars.Count(); i++)
            {
                sum = (int)(sum + stars[i]);
            }
            var average = (double)(sum / stars.Count());
            return average;
        }

    }
}
