using DapperWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DapperWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpPost("register")]
        public async Task<ActionResult<string>> CreateUser(User user)
        {
            return Ok(JsonSerializer.Serialize(GlobalConfig.Connection.UserDao.CreateUser(user)));
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> LoginUser(string username, string password)
        {
            try
            {
                User? user = GlobalConfig.Connection.UserDao.LoginUser(username, password);
                if (user is not null)
                    return Ok(user);
                return BadRequest(JsonSerializer.Serialize("User credentials are not valid"));
            }
            catch
            {
                return BadRequest(JsonSerializer.Serialize("Internal Error"));
            }
        }
    }
}
