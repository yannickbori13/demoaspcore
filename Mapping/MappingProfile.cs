using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Picole.WebApi.Dtos;
using Picole.WebApi.Models;

namespace Picole.WebApi.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Extra, ExtraDto>();
            CreateMap<SaveExtraDto, Extra>();
            CreateMap<Unit, UnitDto>();
            CreateMap<SaveSensorLogDto, SensorLog>()
                .ForMember(x => x.Oid, opt => opt.Ignore())
                .ForMember(x => x.DateTime, opt => opt.Ignore());
            CreateMap<SensorLog, SensorLogDto>();
            CreateMap<FermenterChamberConfiguration, FermenterChamberConfigurationDto>();
            CreateMap<SaveFermenterChamberConfigurationDto, FermenterChamberConfiguration>()
                .ForMember(x => x.Oid, opt => opt.Ignore());
        }

        
    }
}
