﻿
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Picole.WebApi.Models
{
    public class Fermentable
    {
        [Key]
        public Guid Oid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public string Link { get; set; }
    }
}