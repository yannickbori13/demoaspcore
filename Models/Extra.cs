
using System;
using System.ComponentModel.DataAnnotations;

namespace Picole.WebApi.Models
{
    public class Extra
    {
        [Key] public Guid Oid { get; set; }
        public string  Name { get; set; }
        
        public Unit Unit { get; set; }
    }
}
