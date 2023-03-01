using Microsoft.AspNetCore.Mvc;
using Movies.Application.Models;
using Movies.Application.Repositories;
using Movies.Contracts.Requests;

namespace Movies.Api.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieRequest createRequest)
        {
            var movie = new Movie
            {
                Id = Guid.NewGuid(),
                Name = createRequest.Name,
                YearOfRelease = createRequest.YearOfRelease,
                Genres = createRequest.Genres.ToList()
            };

            await _movieRepository.CreateAsync(movie);

            return Created($"api/movies/{movie.Id}", movie);
        }
    }
}
