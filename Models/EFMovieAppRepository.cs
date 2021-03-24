using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class EFMovieAppRepository : IMovieAppRepository
    {
        private MovieAppDbContext _context;

        public EFMovieAppRepository (MovieAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> Movies => _context.Movies;
    }
}
