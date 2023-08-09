using System.ComponentModel.DataAnnotations;

namespace OnePageApp.Dtos.AboutDtos
{
    public class CreateAboutDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ButtonText { get; set; }
    }
}
