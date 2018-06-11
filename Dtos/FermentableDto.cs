using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Picole.WebApi.Dtos
{
    public class FermentableDto
    {
        public Guid Oid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public string Link { get; set; }
    }
}
