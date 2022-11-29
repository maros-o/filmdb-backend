using DapperWebApi.DataAccess.DataAccessObjects;
using DapperWebApi.DataAccess.DataAccessObjects.Csv;

namespace DapperWebApi.DataAccess
{
    public class CsvConnector
    {
        public IMovieDao MovieDao = new MovieCsvDao();
        public IPersonDao PersonDao = new PersonCsvDao();
        public IReviewDao ReviewDao = new ReviewCsvDao();
        public IUserDao UserDao = new UserCsvDao();
    }
}
