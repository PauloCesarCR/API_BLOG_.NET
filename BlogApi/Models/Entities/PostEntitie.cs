using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlogApi.Models.Entities
{
    public class PostEntitie
    {

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
