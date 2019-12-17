using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.ViewModels;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public HomeController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IActionResult> Index()
        {
            var movieList = await _movieRepository.ListAsync();

            var model = movieList.Select(movie => new MoviesViewModel()
            {
                Id = movie.Id,
                Genre = movie.Genre,
                Price = movie.Price,
                ReleaseDate = movie.ReleaseDate,
                Title = movie.Title
            });

            return View(model);
        }
    }
}
