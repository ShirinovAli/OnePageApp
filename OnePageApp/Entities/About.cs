using System.ComponentModel.DataAnnotations;

namespace OnePageApp.Entities
{
    public class About
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ButtonText { get; set; }
    }
}
