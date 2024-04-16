using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public string? Nationality { get; set; }
        public string? WorkState { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }


        // Arabic properties
        public string? TitleArabic { get; set; }
        public string? DescriptionArabic { get; set; }
        public string? NameArabic { get; set; }
        public string? NationalityArabic { get; set; }
        public string? WorkStateArabic { get; set; }
        public string? PhoneArabic { get; set; }
        public string? AddressArabic { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}
