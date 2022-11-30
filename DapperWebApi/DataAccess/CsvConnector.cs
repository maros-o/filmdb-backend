using DapperWebApi.DataAccess.DataAccessObjects;
using DapperWebApi.DataAccess.DataAccessObjects.Csv;

namespace DapperWebApi.DataAccess
{
    public class CsvConnector : IDataConnection
    {
        public IMovieDao MovieDao { get; } = new MovieCsvDao();
        public IPersonDao PersonDao { get; } = new PersonCsvDao();
        public IReviewDao ReviewDao { get; } = new ReviewCsvDao();
        public IUserDao UserDao { get; } = new UserCsvDao();
    }
}
