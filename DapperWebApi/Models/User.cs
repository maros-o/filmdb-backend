using System.Text;

namespace DapperWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public override string ToString()
        {
            StringBuilder sb = new($"{this.Id};{this.Username};{this.Email};{this.Password};");
            return sb.ToString();
        }
    }
}
