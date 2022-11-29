using Dapper;
using DapperWebApi.Models;
using System.Data.SqlClient;

namespace DapperWebApi.DataAccess.DataAccessObjects.Sql
{
    public class PersonSqlDao : IPersonDao
    {
        public List<Person> GetAllPeople()
        {
            using SqlConnection conn = new(GlobalConfig.ConnString);
            return SqlUtils.SelectAllPersons(conn);
        }

        public Person GetPerson(string slug)
        {
            using SqlConnection conn = new(GlobalConfig.ConnString);
            try
            {
                string sql = "SELECT * FROM person WHERE slug = @Slug";
                Person person = conn.Query<Person>(sql, new { Slug = slug }).First();
                person.Country = SqlUtils.GetCountryById(person.Country_id, conn);
                person.Movies = SqlUtils.GetMoviesByPersonId(person.Id, conn);
                return person;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Person();
            }
        }

        public List<Person> GetAllActors()
        {
            using SqlConnection conn = new(GlobalConfig.ConnString);
            return SqlUtils.SelectAllActors(conn);
        }

        public List<Person> GetAllDirectors()
        {
            using SqlConnection conn = new(GlobalConfig.ConnString);
            return SqlUtils.SelectAllDirectors(conn);
        }
    }
}
