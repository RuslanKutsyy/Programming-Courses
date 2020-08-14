using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        public Prisoner()
        {
            this.PrisonerOfficers = new HashSet<OfficerPrisoner>();
            this.Mails = new HashSet<Mail>();
        }
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(20)]
        public string FullName { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required, Range(18, 65)]
        public int Age { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime IncarcerationDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public decimal? Bail { get; set; }
        [Required]
        public int CellId { get; set; }
        public Cell Cell { get; set; }
        public ICollection<Mail> Mails { get; set; }
        public ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
    }
}
