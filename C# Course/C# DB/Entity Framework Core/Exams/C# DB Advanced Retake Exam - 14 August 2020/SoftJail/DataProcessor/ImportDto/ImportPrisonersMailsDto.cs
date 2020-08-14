using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrisonersMailsDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string Fullname { get; set; }
        [Required, RegularExpression("(\\w*)\\s*([A-Za-z]*)$")]
        public string Nickname { get; set; }
        [Required, Range(18, 65)]
        public int Age { get; set; }
        [Required]
        public string IncarcerationDate { get; set; }
        public string ReleaseDate { get; set; }
        public decimal? Bail { get; set; }
        [Required]
        public int CellId { get; set; }
        public List<ImportMailDto> Mails { get; set; }
    }
}