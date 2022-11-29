using DapperWebApi.Models;

namespace DapperWebApi.DataAccess
{
    public static class CsvUtils
    {
        public static string MovieFileName { get; } = "Movies.csv";
        public static string PersonFileName { get; } = "People.csv";
        public static string UserFileName { get; } = "Users.csv";
        public static string ReviewFileName { get; } = "Reviews.csv";
        public static string FullFilePath(this string fileName)
        {
            return "C:/code/web/visprojekt/backend/DapperWebApi/DataAccess/CsvDatabase/"+fileName;
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

        public static List<Movie> GetAllMovies()
        {
            IEnumerable<string> lines = CsvUtils.MovieFileName.FullFilePath().LoadFile();
            List<Movie> result = new();

            foreach (string line in lines)
            {
                Movie movie = new();

                string[] cols = line.Split(MainSeparator);

                movie.Id = int.Parse(cols[0]);
                movie.Title = cols[1];
                movie.Slug = cols[2];
                movie.Description = cols[3];
                movie.Release_year = int.Parse(cols[4]);
                movie.Country = cols[5];
                movie.Image_url = cols[6];

                movie.Average_rating = cols[2];
                movie.Reviews_count = cols[2];
                movie.Actors = cols[2];]
                movie.Directors = null;
                movie.Reviews = null;

                result.Add(itemModel);
            }

            return result;
        }
    }
}
