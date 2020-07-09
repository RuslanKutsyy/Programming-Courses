using System;
using System.Collections.Generic;
using P01_StudentSystem.Data.Models.Enumerations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string Url { get; set; }
        public ResourceType ResourceType { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
