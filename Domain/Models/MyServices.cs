using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MyServices
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? NameServ { get; set; }
        public string? Desc_Serv { get; set; }
        public string? Image { get; set; }

        // Arabic properties
        public string? TitleArabic { get; set; }
        public string? DescriptionArabic { get; set; }
        public string? NameServArabic { get; set; }
        public string? Desc_ServArabic { get; set; }
    }
}
