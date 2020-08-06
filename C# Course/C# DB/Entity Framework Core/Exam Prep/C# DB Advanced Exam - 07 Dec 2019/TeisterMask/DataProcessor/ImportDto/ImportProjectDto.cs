using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectDto
    {
        public string Name { get; set; }
        public string OpenDate { get; set; }
        public string DueDate { get; set; }
    }
}
