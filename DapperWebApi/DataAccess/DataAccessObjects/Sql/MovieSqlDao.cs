using Dapper;
using DapperWebApi.Models;
using System.Data.SqlClient;

namespace DapperWebApi.DataAccess.DataAccessObjects.Sql
{
    public class MovieSqlDao : IMovieDao
    {
        public List<Movie> GetAllMovies()
        {
            using SqlConnection conn = new(GlobalConfig.ConnString);
            return SqlUtils.SelectAllMovies(conn);
        }
        public Movie GetMovie(string slug)
        {
            using SqlConnection conn = new(GlobalConfig.ConnString);
            try
            {
                string sql = "SELECT * FROM movies WHERE slug = @Slug";
                Movie movie = conn.Query<Movie>(sql, new { Slug = slug }).First();
                movie.Average_rating = (int)(SqlUtils.GetMovieAverageRating(movie.Id, conn) * 10);
                movie.Reviews_count = SqlUtils.GetMovieReviewCount(movie.Id, conn);
                movie.Country = SqlUtils.GetCountryById(movie.Country_id, conn);
                movie.Actors = SqlUtils.GetMovieActorsByMovieId(movie.Id, conn);
                movie.Directors = SqlUtils.GetMovieDirectorsByMovieId(movie.Id, conn);
                movie.Reviews = SqlUtils.GetMovieReviewsByMovieId(movie.Id, conn);
                return movie;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Movie();
            }
        }
    }
}
