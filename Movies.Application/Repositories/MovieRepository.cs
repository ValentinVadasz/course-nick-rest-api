﻿using Movies.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Repositories
{
    internal class MovieRepository : IMovieRepository
    {
        private List<Movie> _movies = new();

        public Task<bool> CreateAsync(Movie movie)
        {
            _movies.Add(movie);
            return Task.FromResult(true);
        }

        public Task<Movie?> GetByIdAsync(Guid id)
        {
            var movie = _movies.SingleOrDefault(x => x.Id == id);
            return Task.FromResult(movie);
        }
        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            return Task.FromResult(_movies.AsEnumerable());
        }

        public Task<bool> UpdateAsync(Movie movie)
        {
            var movieIndex = _movies.FindIndex(x => x.Id == movie.Id);
            if (movieIndex == -1)
            {
                return Task.FromResult(false);
            }

            _movies[movieIndex] = movie;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var removedCount = _movies.RemoveAll(x => x.Id == id);
            return Task.FromResult(removedCount > 0);
        }
    }
}
