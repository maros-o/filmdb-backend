using DapperWebApi.Models;

namespace DapperWebApi.DataAccess.DataAccessObjects
{
    public interface IUserDao
    {
        string CreateUser(User user);
        User? LoginUser(string username, string password);
    }
}
