using DapperWebApi.DataAccess.DataAccessObjects;

namespace DapperWebApi.DataAccess
{
    public interface IDataConnection
    {
        public IMovieDao MovieDao { get; }
        public IPersonDao PersonDao { get; }
        public IReviewDao ReviewDao { get; }
        public IUserDao UserDao { get; }
    }
}
