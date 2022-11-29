using DapperWebApi.Models;

namespace DapperWebApi.DataAccess.DataAccessObjects
{
    public interface IPersonDao
    {
        List<Person> GetAllPeople();
        Person GetPerson(string slug);
        List<Person> GetAllActors();
        List<Person> GetAllDirectors();
    }
}
