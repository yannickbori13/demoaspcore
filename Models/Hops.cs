using System;
using System.ComponentModel.DataAnnotations;

namespace Picole.WebApi.Models
{
    public class Hops
    {
        [Key]
        public Guid Oid { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public string Link { get; set; }
        public string Vendor { get; set; }
    }
}