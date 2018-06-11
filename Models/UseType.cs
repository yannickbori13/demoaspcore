using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Picole.WebApi.Models
{
    public class UseType
    {
        [Key] public Guid Oid { get; set; }
        public string Name { get; set; }
    }
}