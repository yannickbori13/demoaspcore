using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Picole.WebApi.Dtos
{
    public class SensorLogDto
    {
        public Guid Oid { get; set; }
        public string Type { get; set; }
        public float Value { get; set; }
        public string FromIp { get; set; }
        public DateTime DateTime { get; set; }
        public string Remark { get; set; }
    }
}
