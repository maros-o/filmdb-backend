using Dapper;
using DapperWebApi.Models;
using System.Data.SqlClient;

namespace DapperWebApi.DataAccess.DataAccessObjects.Sql
{
    public class UserSqlDao : IUserDao
    {
        public string CreateUser(User user)
        {
            using SqlConnection conn = new(GlobalConfig.ConnString);
            try
            {
                conn.ExecuteScalar("INSERT INTO users (username, email, password) VALUES (@Username, @Email, @Password)", user);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "User created";
        }

        public User? LoginUser(string username, string password)
        {
            using SqlConnection conn = new(GlobalConfig.ConnString);
            try
            {
                return conn.Query<User>("SELECT * FROM users WHERE username = @Username AND password = @Password", new { Username = username, Password = password }).First();
            }
            catch
            {
                return null;
            }
        }
    }
}
