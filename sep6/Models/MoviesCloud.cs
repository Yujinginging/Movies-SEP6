using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_sep6.Models
{
    public class MoviesCloud
    {
        [Key]
        public string Name { get; set; }
        public float Year { get; set; }
        public float Stars { get; set; }
        public float Votings { get; set; }
        public float Ratings { get; set; }
    }
}