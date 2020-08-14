using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserDto
    {
        [Required]
        [RegularExpression("^([A-Z][a-z]*)\\s([A-Za-z]*)$")]
        public string FullName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(3, 103)]
        public int Age { get; set; }
        [MinLength(1)]
        public List<ImportUserCardsDto> Cards { get; set; }
    }
}
