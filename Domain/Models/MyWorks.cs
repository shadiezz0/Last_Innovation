using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MyWorks
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }

        // Arabic properties
        public string? TitleArabic { get; set; }
        public string? DescriptionArabic { get; set; }
        public string? NameArabic { get; set; }
    }
}
