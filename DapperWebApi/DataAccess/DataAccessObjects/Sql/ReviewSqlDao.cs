using Dapper;
using DapperWebApi.Models;
using System.Data.SqlClient;

namespace DapperWebApi.DataAccess.DataAccessObjects.Sql
{
    public class ReviewSqlDao : IReviewDao
    {
        public string CreateReview(MovieReview review)
        {
            using SqlConnection conn = new(GlobalConfig.ConnString);
            try
            {
                conn.ExecuteScalar("DELETE FROM movie_review WHERE users_id = @Users_id AND movie_id = @Movie_id", review);
                conn.ExecuteScalar("INSERT INTO movie_review (users_id, movie_id, comment, rating) VALUES (@Users_id, @Movie_id, @Comment, @Rating)", review);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Review created";
        }
    }
}
