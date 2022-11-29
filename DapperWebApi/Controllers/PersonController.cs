using DapperWebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace DapperWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        [HttpGet("all")]
        public async Task<ActionResult<List<Person>>> GetAllPeople()
        {
            return Ok(GlobalConfig.Connection.PersonDao.GetAllPeople());
        }

        [HttpGet("all/{slug}")]
        public async Task<ActionResult<Person>> GetPerson(string slug)
        {
            return Ok(GlobalConfig.Connection.PersonDao.GetPerson(slug));
        }

        [HttpGet("actors")]
        public async Task<ActionResult<List<Person>>> GetAllActors()
        {
            return Ok(GlobalConfig.Connection.PersonDao.GetAllActors());
        }

        [HttpGet("directors")]
        public async Task<ActionResult<List<Person>>> GetAllDirectors()
        {
            return Ok(GlobalConfig.Connection.PersonDao.GetAllDirectors());
        }
    }
}
