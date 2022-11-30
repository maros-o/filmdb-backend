using DapperWebApi.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Data.SqlClient;

namespace DapperWebApi.DataAccess.DataAccessObjects.Csv
{
    public class UserCsvDao : IUserDao
    {
        public string CreateUser(User userCreate)
        {
            IEnumerable<string> lines = CsvUtils.UsersFileName.FullFilePath().LoadFile();

            List<User> users = new();

            foreach (string line in lines)
            {
                User user = new();

                string[] cols = line.Split(CsvUtils.MainSeparator);

                user.Id = Convert.ToInt32(cols[0]);
                user.Username = cols[1];
                user.Email = cols[2];
                user.Password = cols[3];

                users.Add(user);
            }

            if (users.Count > 0)
            {
                userCreate.Id = users[users.Count - 1].Id + 1;
            }
            else
            {
                userCreate.Id = 1;
            }

            users.Add(userCreate);

            CsvUtils.SaveToFile<User>(users, CsvUtils.UsersFileName);

            return "User created";
        }

        public User? LoginUser(string username, string password)
        {
            IEnumerable<string> lines = CsvUtils.UsersFileName.FullFilePath().LoadFile();

            foreach (string line in lines)
            {
                User user = new();

                string[] cols = line.Split(CsvUtils.MainSeparator);

                user.Id = Convert.ToInt32(cols[0]);
                user.Username = cols[1];
                user.Email = cols[2];
                user.Password = cols[3];

                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
