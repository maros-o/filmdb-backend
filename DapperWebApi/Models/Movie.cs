using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DapperWebApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Length { get; set; }
        public int Release_year { get; set; }
        [NotMapped]
        public int Country_id { get; set; }
        public string Image_url { get; set; } = string.Empty;
        public int Average_rating { get; set; }
        public int Reviews_count { get; set; }
        public string Country { get; set; } = string.Empty;
        public List<NameSlug> Actors { get; set; } = new();
        public List<NameSlug> Directors { get; set; } = new();
        public List<MovieReview> Reviews { get; set; } = new();
    }
}
