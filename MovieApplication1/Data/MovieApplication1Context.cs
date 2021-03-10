using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieApplication1.Models;

namespace MovieApplication1.Data
{
    public class MovieApplication1Context : DbContext
    {
        public MovieApplication1Context (DbContextOptions<MovieApplication1Context> options)
            : base(options)
        {
        }

        public DbSet<MovieApplication1.Models.Movie> Movie { get; set; }
    }
}
