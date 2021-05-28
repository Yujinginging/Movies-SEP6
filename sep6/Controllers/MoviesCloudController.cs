using Microsoft.AspNetCore.Mvc;
using Movies_sep6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_sep6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesCloudController : Controller
    {
        //1.GET: api/MoviesCloud/MoviesPerYear
        [HttpGet("[action]")]
        public Dictionary<float, int> MoviesPerYear()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesFromCloud.Select(f => f.Year).ToList().GroupBy(m => m).OrderBy(g => g.Key).ToDictionary(g => g.Key, g => g.Count());
        }

        //2.GET: api/MoviesCloud/MoviesPerStars
        [HttpGet("[action]")]
        public Dictionary<float, int> MoviesPerStars()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesFromCloud.Select(f => f.Stars).ToList().GroupBy(m => m).OrderBy(g => g.Key).ToDictionary(g => g.Key, g => g.Count());
        }

        //3.GET: api/MoviesCloud/MoviesPerVotings
        [HttpGet("[action]")]
        public Dictionary<float, int> MoviesPerVotings()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesFromCloud.Select(f => f.Votings).ToList().GroupBy(m => m).OrderBy(g => g.Key).ToDictionary(g => g.Key, g => g.Count());
        }

        //4.GET: api/MoviesCloud/MoviesPerRatings
        [HttpGet("[action]")]
        public Dictionary<float, int> MoviesPerRatings()
        {
            var context = new MoviesCloudDBContext();

            return context.MoviesFromCloud.Select(f => f.Ratings).ToList().GroupBy(m => m).OrderBy(g => g.Key).ToDictionary(g => g.Key, g => g.Count());
        }

    }
}