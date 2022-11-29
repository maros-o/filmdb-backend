using DapperWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DapperWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {

        [HttpPost("create_movie_review")]
        public async Task<ActionResult<string>> CreateReview(MovieReview review)
        {
            return Ok(JsonSerializer.Serialize(GlobalConfig.Connection.ReviewDao.CreateReview(review)));
        }
    }
}
