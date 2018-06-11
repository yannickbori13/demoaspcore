using System;

namespace Picole.WebApi.Dtos
{
    public class HopsDto
    {
        public Guid Oid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Vendor { get; set; }
    }
}
