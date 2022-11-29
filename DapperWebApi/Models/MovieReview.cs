using Microsoft.AspNetCore.Http;
using System.Text;

namespace DapperWebApi.Models
{
    public class MovieReview
    {
        public int Users_id { get; set; }
        public int Movie_id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateTime Create_date { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new($"{this.Users_id};{this.Movie_id};{this.Username};{this.Comment};{this.Rating};{this.Create_date};");
            return sb.ToString();
        }
    }
}
