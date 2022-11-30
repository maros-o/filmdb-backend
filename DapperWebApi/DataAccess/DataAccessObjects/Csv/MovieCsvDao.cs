using DapperWebApi.Models;

namespace DapperWebApi.DataAccess.DataAccessObjects.Csv
{
    public class MovieCsvDao : IMovieDao
    {
        public List<Movie> GetAllMovies()
        {
            IEnumerable<string> lines = CsvUtils.MoviesFileName.FullFilePath().LoadFile();
            List<Movie> result = new();

            foreach (string line in lines)
            {
                Movie movie = new();

                string[] cols = line.Split(CsvUtils.MainSeparator);

                movie.Id = int.Parse(cols[0]);
                movie.Title = cols[1];
                movie.Slug = cols[2];
                movie.Description = cols[3];
                movie.Length = int.Parse(cols[4]);
                movie.Release_year = int.Parse(cols[5]);
                movie.Country = cols[6];
                movie.Image_url = cols[7];

                movie.Average_rating = CsvUtils.GetAverageRatingCountByMovieId(movie.Id, out int count);
                movie.Reviews_count = count;

                movie.Actors = CsvUtils.GetActorNameSlugsByMovieId(movie.Id);
                movie.Directors = CsvUtils.GetDirectorNameSlugsByMovieId(movie.Id);

                result.Add(movie);
            }

            return result;
        }
        public Movie GetMovie(string slug)
        {
            IEnumerable<string> lines = CsvUtils.MoviesFileName.FullFilePath().LoadFile();

            foreach (string line in lines)
            {
                string[] cols = line.Split(CsvUtils.MainSeparator);

                if (cols[2] != slug) continue;

                Movie movie = new()
                {
                    Id = int.Parse(cols[0]),
                    Title = cols[1],
                    Slug = cols[2],
                    Description = cols[3],
                    Length = int.Parse(cols[4]),
                    Release_year = int.Parse(cols[5]),
                    Country = cols[6],
                    Image_url = cols[7],
                };

                movie.Average_rating = CsvUtils.GetAverageRatingCountByMovieId(movie.Id, out int count);
                movie.Reviews_count = count;
                movie.Actors = CsvUtils.GetActorNameSlugsByMovieId(movie.Id);
                movie.Directors = CsvUtils.GetDirectorNameSlugsByMovieId(movie.Id);
                movie.Reviews = CsvUtils.GetMovieReviewsByMovieId(movie.Id);

                return movie;
            }

            return new Movie();
        }
    }
}
