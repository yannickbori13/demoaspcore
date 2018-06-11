using System;

namespace Picole.WebApi.Dtos
{
    public class YeastDto
    {
        public Guid Oid { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string ProductNumber { get; set; }
        public string Vendor { get; set; }
    }
}
