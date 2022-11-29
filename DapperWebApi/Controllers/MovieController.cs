using DapperWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IConfiguration _config;

        public MovieController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            return Ok(GlobalConfig.Connection.MovieDao.GetAllMovies());
        }

        [HttpGet("all/{slug}")]
        public async Task<ActionResult<Movie>> GetMovie(string slug)
        {
            return Ok(GlobalConfig.Connection.MovieDao.GetMovie(slug));
        }

        /*
        [HttpPost]
        public async Task<ActionResult<List<Movie>>> CreateMovie(Movie movie)
        {
            using SqlConnection conn = new(_config.GetConnectionString("DefaultConnection"));
            await conn.ExecuteAsync("INSERT INTO movies (title) VALUES (@Title)", movie);
            return Ok(await SelectAllMovies(conn));
        }

        [HttpPut]
        public async Task<ActionResult<List<Movie>>> UpdateMovie(Movie movie)
        {
            using SqlConnection conn = new(_config.GetConnectionString("DefaultConnection"));
            await conn.ExecuteAsync("UPDATE movies SET title = @Title WHERE id = @Id", movie);
            return Ok(await SelectAllMovies(conn));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Movie>>> DeleteMovie(int id)
        {
            using SqlConnection conn = new(_config.GetConnectionString("DefaultConnection"));
            await conn.ExecuteAsync("DELETE FROM movies WHERE id = @Id", new { Id = id });
            return Ok(await SelectAllMovies(conn));
        }
        */
    }
}
