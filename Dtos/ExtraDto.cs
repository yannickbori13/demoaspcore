
using System;
using Picole.WebApi.Models;

namespace Picole.WebApi.Dtos
{
    public class ExtraDto
    {
        public Guid Oid { get; set; }
        public string Name { get; set; }
        public UnitDto Unit { get; set; }
    }
}
