using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_blog
{
    public class Post
    {
        [JsonIgnore]
        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        [Required]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        public string? Image { get; set; } 

        public string? DescriptionImage { get; set; }

    }
}