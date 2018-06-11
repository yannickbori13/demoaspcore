using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Picole.WebApi.Models
{
    public class Unit
    {
        [Key] public Guid Oid { get; set; }
        public string Name { get; set; }
        public ICollection<Extra> Extras { get; set; }
    }
}