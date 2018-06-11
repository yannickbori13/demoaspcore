using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Picole.WebApi.Dtos
{
    public class SaveFermenterChamberConfigurationDto
    {
        public int TemperatureMaximum { get; set; }
        public int TemperatureMinimum { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReportDelay { get; set; }
    }
}
