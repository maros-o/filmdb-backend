using DapperWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.DataAccess.DataAccessObjects
{
    public interface IMovieDao
    {
        List<Movie> GetAllMovies();
        Movie GetMovie(string slug);
    }
}
