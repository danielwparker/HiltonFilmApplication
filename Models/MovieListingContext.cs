using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiltonFilmApplication.Models
{
    public class MovieListingContext : DbContext
    {
        public MovieListingContext(DbContextOptions<MovieListingContext> options) : base (options)
        {

        }

        public DbSet<MovieListing> Movies { get; set; }
    }
}
