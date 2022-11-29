namespace DapperWebApi.Models
{
    public class NameSlug
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public NameSlug(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }
    }
}
