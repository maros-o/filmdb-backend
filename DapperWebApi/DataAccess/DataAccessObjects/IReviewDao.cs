using DapperWebApi.Models;

namespace DapperWebApi.DataAccess.DataAccessObjects
{
    public interface IReviewDao
    {
        string CreateReview(MovieReview review);
    }
}
