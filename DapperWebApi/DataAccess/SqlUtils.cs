using Dapper;
using DapperWebApi.Models;
using System.Data.SqlClient;

namespace DapperWebApi.DataAccess
{
    public class SqlUtils
    {
        public static List<Movie> GetMoviesByPersonId(int personId, SqlConnection conn)
        {
            string sql = "SELECT * FROM movies WHERE movies.id IN (SELECT movie_actor.movie_id FROM movie_actor WHERE movie_actor.person_id = @Id) OR movies.id IN (SELECT movie_director.movie_id FROM movie_director WHERE movie_director.person_id = @Id)";
            return conn.Query<Movie>(sql, new { Id = personId }).ToList();
        }

        public static int GetMovieReviewCount(int movieId, SqlConnection conn)
        {
            string sql = "SELECT count(*) FROM movie_review WHERE movie_id = @Id";
            int? count = conn.Query<int?>(sql, new { Id = movieId }).First();
            if (count is null) return 0;
            return (int)count;
        }

        public static float GetMovieAverageRating(int movieId, SqlConnection conn)
        {
            string sql = "SELECT AVG(Cast(rating as Float)) FROM movie_review WHERE movie_id = @Id";
            float? avg = conn.Query<float?>(sql, new { Id = movieId }).First();
            if (avg is null) return 0;
            return (float)avg;
        }

        public static string GetCountryById(int countryId, SqlConnection conn)
        {
            string sql = "SELECT name FROM countries WHERE id = @Id";
            return conn.Query<string>(sql, new { Id = countryId }).First();
        }

        public static List<NameSlug> GetMovieActorsByMovieId(int movieId, SqlConnection conn)
        {
            string sql = "SELECT person.name, person.slug FROM person WHERE person.id IN (SELECT movie_actor.person_id FROM movie_actor WHERE movie_actor.movie_id = @Id)";
            return conn.Query<NameSlug>(sql, new { Id = movieId }).ToList();
        }

        public static List<NameSlug> GetMovieDirectorsByMovieId(int movieId, SqlConnection conn)
        {
            string sql = "SELECT person.name, person.slug FROM person WHERE person.id IN (SELECT movie_director.person_id FROM movie_director WHERE movie_director.movie_id = @Id)";
            return conn.Query<NameSlug>(sql, new { Id = movieId }).ToList();
        }

        public static List<MovieReview> GetMovieReviewsByMovieId(int movieId, SqlConnection conn)
        {
            string sql = "SELECT review.users_id, review.movie_id, users.username, review.comment, review.rating, review.create_date FROM movie_review review JOIN users ON users.id = review.users_id WHERE review.movie_id = @Id ORDER BY review.create_date DESC";
            return conn.Query<MovieReview>(sql, new { Id = movieId }).ToList();
        }

        public static List<Person> SelectAllPersons(SqlConnection conn)
        {
            string sql = "SELECT * FROM person";
            List<Person> people = conn.Query<Person>(sql).ToList();
            foreach (Person person in people)
            {
                person.Country = GetCountryById(person.Country_id, conn);
            }
            return people;
        }

        public static List<Person> SelectAllActors(SqlConnection conn)
        {
            string sql = "SELECT * FROM person WHERE person.id IN (SELECT DISTINCT person_id FROM movie_actor)";
            List<Person> people = conn.Query<Person>(sql).ToList();
            foreach (Person person in people)
            {
                person.Country = GetCountryById(person.Country_id, conn);
                person.Movies = GetMoviesByPersonId(person.Id, conn);
            }
            return people;
        }

        public static List<Person> SelectAllDirectors(SqlConnection conn)
        {
            string sql = "SELECT * FROM person WHERE person.id IN (SELECT DISTINCT person_id FROM movie_director)";
            List<Person> people = conn.Query<Person>(sql).ToList();
            foreach (Person person in people)
            {
                person.Country = GetCountryById(person.Country_id, conn);
                person.Movies = GetMoviesByPersonId(person.Id, conn);
            }
            return people;
        }

        public static List<Movie> SelectAllMovies(SqlConnection conn)
        {
            string sql = "SELECT * FROM movies";
            List<Movie> movies = conn.Query<Movie>(sql).ToList();
            foreach (Movie movie in movies)
            {
                movie.Country = GetCountryById(movie.Country_id, conn);

                movie.Average_rating = (int)(GetMovieAverageRating(movie.Id, conn) * 10);
                movie.Reviews_count = GetMovieReviewCount(movie.Id, conn);
                movie.Actors = GetMovieActorsByMovieId(movie.Id, conn);
                movie.Directors = GetMovieDirectorsByMovieId(movie.Id, conn);
            }
            return movies;
        }
    }
}
