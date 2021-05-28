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
       
        //1.GET: MoviesCloud/MoviesPerYear
        [HttpGet("[action]")]
        public Dictionary<float, int> MoviesPerYear()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.Select(f => f.Year).ToList().GroupBy(m => m).OrderBy(g => g.Key).ToDictionary(g => g.Key, g => g.Count());
        }

        //2.GET: MoviesCloud/MoviesPerStars
        [HttpGet("[action]")]
        public Dictionary<float, int> MoviesPerStars()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.Select(f => f.Stars).ToList().GroupBy(m => m).OrderBy(g => g.Key).ToDictionary(g => g.Key, g => g.Count());
        }

        //3.GET: MoviesCloud/MoviesPerVotings
        [HttpGet("[action]")]
        public Dictionary<float, int> MoviesPerVotings()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.Select(f => f.Votings).ToList().GroupBy(m => m).OrderBy(g => g.Key).ToDictionary(g => g.Key, g => g.Count());
        }

        //4.GET: MoviesCloud/MoviesTopTenRatings
        [HttpGet("[action]")]
        public List<float> MoviesTopTenRatings()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.Select(f => f.Ratings).Take(10).ToList();
        }

        //5.GET:MoviesCloud/GetTopTenMovies
        [HttpGet("[action]")]
        public List<string> GetTopTenMovies()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.Select(f => f.Name).Take(10).ToList(); ;
        }
        //6.GET:MoviesCloud/GetTopTenVotes
        [HttpGet("[action]")]
        public List<float> GetTopTenVotes()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.Select(f => f.Votings).Take(10).ToList(); ;
        }
        //7.GET:MoviesCloud/GetTopTenStars
        [HttpGet("[action]")]
        public List<float> GetTopTenStars()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesCloud.Select(f => f.Stars).Take(10).ToList(); ;
        }



    }
}
