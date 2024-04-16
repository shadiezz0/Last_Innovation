using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Job { get; set; }
        public string? Image { get; set; }

        // Arabic properties
        public string? NameArabic { get; set; }
    }
}
