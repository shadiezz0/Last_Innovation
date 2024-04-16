using System.ComponentModel.DataAnnotations;


namespace Core.Models
{
    public class Header
    {
        [Key]
        public int Id { get; set; }
        public string? Image { get; set; }
        // Resource key for Description
        public string? Description { get; set; }

        // Resource key for Arabic Description
        public string? DescriptionArabic { get; set; }

    }
}
