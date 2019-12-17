using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcMovie.Models;

namespace MvcMovie.Data
{
   public interface IMovieRepository
    {
        Task<Movie> GetByIdAsync(int id);
        Task<List<Movie>> ListAsync();
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
    }
}
