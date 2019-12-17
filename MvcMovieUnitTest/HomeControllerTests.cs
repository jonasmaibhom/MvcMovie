using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MvcMovie.Controllers;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.ViewModels;
using Xunit;

namespace MvcMovieUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfMovies()
        {
            // Arrange
            var mockRepo = new Mock<IMovieRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestMovies);
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<MoviesViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        private List<Movie> GetTestMovies()
        {
            var movies = new List<Movie>();
            movies.Add(new Movie()
            {
                Genre = "Horror",
                Id = 1,
                Price = 400,
                ReleaseDate = DateTime.Now,
                Title = "SpongeBob"

            });
            movies.Add(new Movie()
            {
                Genre = "Comedy",
                Id = 2,
                Price = 200,
                ReleaseDate = DateTime.Now,
                Title = "Joker"
            });
            return movies;
        }
    }
}