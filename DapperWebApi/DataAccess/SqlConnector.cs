using DapperWebApi.DataAccess.DataAccessObjects;
using DapperWebApi.DataAccess.DataAccessObjects.Sql;

namespace DapperWebApi.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        public IMovieDao MovieDao { get; } = new MovieSqlDao();
        public IPersonDao PersonDao { get; } = new PersonSqlDao();
        public IReviewDao ReviewDao { get; } = new ReviewSqlDao();
        public IUserDao UserDao { get; } = new UserSqlDao();
    }
}
