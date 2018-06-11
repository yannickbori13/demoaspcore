using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Picole.WebApi.Dtos
{
    public class SaveExtraDto
    {
        public Guid Oid { get; set; }
        public string Name { get; set; }
        public string UnitOid { get; set; }
    }
}
