using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Picole.WebApi.Models
{
    public class FermenterChamberConfiguration
    {
        [Key] public Guid Oid { get; set; }
        public int TemperatureMaximum { get; set; }
        public int TemperatureMinimum { get; set; }
        public int ReportDelay { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
