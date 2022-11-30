using DapperWebApi.Models;

namespace DapperWebApi.DataAccess
{
    public static class CsvUtils
    {
        public static string MoviesFileName { get; } = "Movies.csv";
        public static string MovieActorsFileName { get; } = "MovieActors.csv";
        public static string MovieDirectorsFileName { get; } = "MovieDirectors.csv";
        public static string PeopleFileName { get; } = "People.csv";
        public static string UsersFileName { get; } = "Users.csv";
        public static string ReviewsFileName { get; } = "Reviews.csv";
        public static string FullFilePath(this string fileName)
        {
            return "C:/code/web/visprojekt/backend/DapperWebApi/DataAccess/CsvDatabase/" + fileName;
        }
        public static char MainSeparator { get; } = ';';

        public static IEnumerable<string> LoadFile(this string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
                return new List<string>();
            }

            return File.ReadAllLines(filePath);
        }

        public static void SaveToFile<T>(this IEnumerable<T> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (var model in models)
            {
                lines.Add(model.ToString());
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static int GetAverageRatingCountByMovieId(int movie_id, out int count)
        {
            IEnumerable<string> lines = CsvUtils.ReviewsFileName.FullFilePath().LoadFile();

            int sum = 0;
            int c = 0;

            foreach (string line in lines)
            {
                MovieReview review = new();

                string[] cols = line.Split(MainSeparator);

                if (int.Parse(cols[1]) != movie_id) continue;

                sum += int.Parse(cols[4]);
                c++;
            }

            count = c;

            if (sum == 0) return 0;

            return (int)((float)sum / c * 10);
        }

        public static List<NameSlug> GetActorNameSlugsByMovieId(int movie_id)
        {
            IEnumerable<string> lines = CsvUtils.MovieActorsFileName.FullFilePath().LoadFile();
            List<int> personIds = new();

            foreach (string line in lines)
            {
                string[] cols = line.Split(MainSeparator);

                if (int.Parse(cols[1]) == movie_id) personIds.Add(int.Parse(cols[0]));
            }

            return GetPersonNameSlugsByIdList(personIds);
        }

        public static List<NameSlug> GetDirectorNameSlugsByMovieId(int movie_id)
        {
            IEnumerable<string> lines = CsvUtils.MovieDirectorsFileName.FullFilePath().LoadFile();
            List<int> personIds = new();

            foreach (string line in lines)
            {
                string[] cols = line.Split(MainSeparator);

                if (int.Parse(cols[1]) == movie_id) personIds.Add(int.Parse(cols[0]));
            }

            return GetPersonNameSlugsByIdList(personIds);
        }

        public static List<NameSlug> GetPersonNameSlugsByIdList(List<int> personIds)
        {
            List<NameSlug> nameSlugs = new();
            IEnumerable<string> lines = CsvUtils.PeopleFileName.FullFilePath().LoadFile();

            foreach (string line in lines)
            {
                string[] cols = line.Split(MainSeparator);

                int personId = int.Parse(cols[0]);

                if (IsIntInList(personId, personIds))
                {
                    personIds.Remove(personId);
                    nameSlugs.Add(new(cols[1], cols[2]));
                }
            }

            return nameSlugs;
        }

        public static List<MovieReview> GetMovieReviewsByMovieId(int movieId)
        {
            List<MovieReview> reviews = new();
            IEnumerable<string> lines = CsvUtils.ReviewsFileName.FullFilePath().LoadFile();

            foreach (string line in lines)
            {
                string[] cols = line.Split(MainSeparator);

                if (int.Parse(cols[1]) == movieId)
                {
                    MovieReview rev = new();
                    rev.Users_id = int.Parse(cols[0]);
                    rev.Movie_id = int.Parse(cols[1]);
                    rev.Username = cols[2];
                    rev.Comment = cols[3];
                    rev.Rating= int.Parse(cols[4]);
                    rev.Create_date = DateTime.Parse(cols[5]);

                    reviews.Add(rev);
                }
            }

            return reviews;
        }

        public static List<Movie> GetMoviesByPersonId(int personId)
        {
            List<int> movieIds = new();

            IEnumerable<string> lines = CsvUtils.MovieActorsFileName.FullFilePath().LoadFile();

            foreach (string line in lines)
            {
                string[] cols = line.Split(MainSeparator);

                if (int.Parse(cols[0]) == personId) movieIds.Add(int.Parse(cols[1]));
            }

            lines = CsvUtils.MovieDirectorsFileName.FullFilePath().LoadFile();

            foreach (string line in lines)
            {
                string[] cols = line.Split(MainSeparator);

                if (int.Parse(cols[0]) == personId) movieIds.Add(int.Parse(cols[1]));
            }

            return GetMoviesByMovieIds(movieIds);
        }

        public static List<Movie> GetMoviesByMovieIds(List<int> movieIds)
        {
            IEnumerable<string> lines = CsvUtils.MoviesFileName.FullFilePath().LoadFile();
            List<Movie> result = new();

            foreach (string line in lines)
            {
                Movie movie = new();

                string[] cols = line.Split(CsvUtils.MainSeparator);

                movie.Id = int.Parse(cols[0]);

                if (!IsIntInList(movie.Id, movieIds))
                {
                    continue;
                }
                movieIds.Remove(movie.Id);

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

        public static bool IsIntInList(int value, List<int> list)
        {
            foreach(int i in list)
            {
                if (value == i) return true;
            }
            return false;
        }
    }
}
