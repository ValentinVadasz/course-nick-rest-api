﻿using Movies.Application.Models;

namespace Movies.Application.Repositories
{
    public interface IMovieRepository
    {
        public Task<bool> CreateAsync(Movie movie);
        public Task<Movie?> GetByIdAsync(Guid id);
        public Task<Movie?> GetBySlugAsync(string slug);
        public Task<IEnumerable<Movie>> GetAllAsync();
        public Task<bool> UpdateAsync(Movie movie);
        public Task<bool> DeleteByIdAsync(Guid id);
    }
}
