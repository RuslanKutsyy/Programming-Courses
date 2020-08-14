using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DataProcessor.ImportDto
{
    public class ImportHallSeatDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public bool Is4Dx { get; set; }
        [Required]
        public bool Is3D { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Seats { get; set; }
    }
}