using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public static class Storage
    {
        private static List<Movie> movies = new List<Movie>();
        public static IEnumerable<Movie> Movies => movies;
        public static void AddMovie(Movie response)
        {
            movies.Add(response);
        }
    }
}
