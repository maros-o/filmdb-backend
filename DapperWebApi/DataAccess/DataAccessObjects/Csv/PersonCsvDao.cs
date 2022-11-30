using DapperWebApi.Models;
using System.Data.SqlClient;

namespace DapperWebApi.DataAccess.DataAccessObjects.Csv
{
    public class PersonCsvDao : IPersonDao
    {
        public List<Person> GetAllPeople()
        {
            IEnumerable<string> lines = CsvUtils.PeopleFileName.FullFilePath().LoadFile();
            List<Person> result = new();

            foreach (string line in lines)
            {
                Person person = new();

                string[] cols = line.Split(CsvUtils.MainSeparator);

                person.Id = int.Parse(cols[0]);
                person.Name = cols[1];
                person.Slug = cols[2];
                person.Description = cols[3];
                person.Birth_year = int.Parse(cols[4]);
                person.Country = cols[5];
                person.Image_url = cols[6];
                person.Movies = CsvUtils.GetMoviesByPersonId(person.Id);

                result.Add(person);
            }

            return result;
        }

        public Person GetPerson(string slug)
        {
            IEnumerable<string> lines = CsvUtils.PeopleFileName.FullFilePath().LoadFile();

            foreach (string line in lines)
            {
                Person person = new();

                string[] cols = line.Split(CsvUtils.MainSeparator);

                person.Slug = cols[2];

                if (person.Slug != slug) continue;

                person.Id = int.Parse(cols[0]);
                person.Name = cols[1];
                person.Description = cols[3];
                person.Birth_year = int.Parse(cols[4]);
                person.Country = cols[5];
                person.Image_url = cols[6];
                person.Movies = CsvUtils.GetMoviesByPersonId(person.Id);

                return person;
            }

            return new Person();
        }

        public List<Person> GetAllActors()
        {
            IEnumerable<string> lines = CsvUtils.MovieActorsFileName.FullFilePath().LoadFile();
            List<int> actorIds = new();

            foreach (string line in lines)
            {
                string[] cols = line.Split(CsvUtils.MainSeparator);

                int actorId = int.Parse(cols[0]);

                if (!CsvUtils.IsIntInList(actorId, actorIds))
                {
                    actorIds.Add(actorId);
                }
            }

            List<Person> allPeople = GetAllPeople();
            List<Person> result = new();

            foreach(Person person in allPeople)
            {
                if (CsvUtils.IsIntInList(person.Id, actorIds))
                {
                    result.Add(person);
                }
            }

            return result;
        }

        public List<Person> GetAllDirectors()
        {
            IEnumerable<string> lines = CsvUtils.MovieDirectorsFileName.FullFilePath().LoadFile();
            List<int> directorIds = new();

            foreach (string line in lines)
            {
                string[] cols = line.Split(CsvUtils.MainSeparator);

                int directorId = int.Parse(cols[0]);

                if (!CsvUtils.IsIntInList(directorId, directorIds))
                {
                    directorIds.Add(directorId);
                }
            }

            List<Person> allPeople = GetAllPeople();
            List<Person> result = new();

            foreach (Person person in allPeople)
            {
                if (CsvUtils.IsIntInList(person.Id, directorIds))
                {
                    result.Add(person);
                }
            }

            return result;
        }
    }
}
