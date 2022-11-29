namespace DapperWebApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Birth_year { get; set; }
        public int Country_id { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Image_url { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; } = new();
    }
}
