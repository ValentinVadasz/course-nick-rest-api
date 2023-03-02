using Movies.Application.Models;

namespace Movies.Application.Repositories
{
    public interface IMovieRepository
    {
        public Task<bool> CreateAsync(Movie movie, CancellationToken token = default);
        public Task<Movie?> GetByIdAsync(Guid id, CancellationToken token = default);
        public Task<Movie?> GetBySlugAsync(string slug, CancellationToken token = default);
        public Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default);
        public Task<bool> UpdateAsync(Movie movie, CancellationToken token = default);
        public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
        public Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default);
    }
}
