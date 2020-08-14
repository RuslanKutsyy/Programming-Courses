using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentsCellsDto
    {
        [Required, MinLength(3), MaxLength(25)]
        public string Name { get; set; }
        [MinLength(1)]
        public List<ImportCellDto> Cells { get; set; }
    }
}