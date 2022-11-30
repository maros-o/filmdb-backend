using DapperWebApi.Models;
using System.Data.SqlClient;

namespace DapperWebApi.DataAccess.DataAccessObjects.Csv
{
    public class ReviewCsvDao : IReviewDao
    {
        public string CreateReview(MovieReview review)
        {
            IEnumerable<string> lines = CsvUtils.ReviewsFileName.FullFilePath().LoadFile();

            List<MovieReview> reviews = new();

            foreach (string line in lines)
            {
                MovieReview rev = new();

                string[] cols = line.Split(CsvUtils.MainSeparator);

                rev.Users_id = int.Parse(cols[0]);
                rev.Movie_id = int.Parse(cols[1]);
                rev.Username = cols[2];
                rev.Comment = cols[3];
                rev.Rating = int.Parse(cols[4]);
                rev.Create_date = DateTime.Parse(cols[5]);

                if (!(rev.Movie_id == review.Movie_id && rev.Users_id == review.Users_id))
                {
                    reviews.Add(rev);
                }
            }

            review.Create_date = DateTime.Now;
            reviews.Add(review);

            CsvUtils.SaveToFile<MovieReview>(reviews, CsvUtils.ReviewsFileName);

            return "Review Created";
        }
    }
}
