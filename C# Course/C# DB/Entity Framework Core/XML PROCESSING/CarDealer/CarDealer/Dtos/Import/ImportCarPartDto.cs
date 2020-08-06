using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Part")]
    public class ImportCarPartDto
    {
        [XmlElement("partId")]
        public int PartId { get; set; }
    }
}
