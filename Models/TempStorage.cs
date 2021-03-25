using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiltonFilmApplication.Models
{
    public class TempStorage
    {
        private static List<MovieListing> movies = new List<MovieListing>();
        public static IEnumerable<MovieListing> Movies => movies;
        public static void AddMovie(MovieListing movie)
        {
            movies.Add(movie);
        }
    }
}
