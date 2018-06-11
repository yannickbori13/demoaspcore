using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picole.WebApi.Dtos;
using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/FermenterChamberConfiguration")]
    public class FermenterChamberConfigurationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFermenterChamberConfigurationRepository _fermenterChamberConfigurationRepository;
        private readonly IMapper _mapper;

        public FermenterChamberConfigurationController(
            IUnitOfWork unitOfWork,
            IFermenterChamberConfigurationRepository fermenterChamberConfigurationRepository,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _fermenterChamberConfigurationRepository = fermenterChamberConfigurationRepository;
            _mapper = mapper;
        }

        [HttpPut("name/{name}")]
        public IActionResult Updtate(string name,
            [FromBody] SaveFermenterChamberConfigurationDto saveFermenterChamberConfigurationDto)
        {
            var fermenterConfig = _fermenterChamberConfigurationRepository.Find(x => x.Name == name);
            if (fermenterConfig == null)
                return NotFound();

            fermenterConfig =_mapper.Map(saveFermenterChamberConfigurationDto, fermenterConfig);
            _fermenterChamberConfigurationRepository.Update(fermenterConfig);
            _unitOfWork.Complete();
            return Ok(fermenterConfig);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SaveFermenterChamberConfigurationDto fermenterChamberConfigurationDto)
        {
            var fermenterChamber = _mapper.Map<FermenterChamberConfiguration>(fermenterChamberConfigurationDto);
            _fermenterChamberConfigurationRepository.Insert(fermenterChamber);
            _unitOfWork.Complete();
            return Ok(_mapper.Map<FermenterChamberConfigurationDto>(fermenterChamber));
        }

        [HttpGet("{oid}")]
        public IActionResult GetFermenterChamberConfiguration(string oid)
        {
            var fermenterChamberDb = _fermenterChamberConfigurationRepository.Find(x => x.Oid == new Guid(oid));
            if (fermenterChamberDb == null)
                return NotFound();

            return Ok(_mapper.Map<FermenterChamberConfigurationDto>(fermenterChamberDb));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var fermenterChamberConfigurationDb = _fermenterChamberConfigurationRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<FermenterChamberConfigurationDto>>(fermenterChamberConfigurationDb));
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var fermenterChamberDb = _fermenterChamberConfigurationRepository.Find(x => x.Name == name);
            if (fermenterChamberDb == null)
                return NotFound("ici");

            return Ok(_mapper.Map<FermenterChamberConfigurationDto>(fermenterChamberDb));
        }
    }
}