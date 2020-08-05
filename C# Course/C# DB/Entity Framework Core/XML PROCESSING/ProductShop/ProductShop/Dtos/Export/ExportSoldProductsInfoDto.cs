using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class ExportSoldProductsInfoDto
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("products")]
        public List<ExportUserProductInfoDto> Products { get; set; }
    }
}
