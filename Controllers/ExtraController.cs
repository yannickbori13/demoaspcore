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
    [Route("api/Extra")]
    public class ExtraController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExtraRepository _extraRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        private Extra extra;

        public ExtraController(
            IUnitOfWork unitOfWork,
            IExtraRepository extraRepository,
            IUnitRepository unitRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _extraRepository = extraRepository;
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] SaveExtraDto saveExtraDto)
        {
            var unit = _unitRepository.Find(x=>x.Oid == new Guid(saveExtraDto.UnitOid));
            if (unit == null)
                return NotFound("Unit not found");
            var extra = _mapper.Map<SaveExtraDto, Extra>(saveExtraDto);
            extra.Unit = unit;
            _extraRepository.Insert(extra);
            _unitOfWork.Complete();
            return Ok(_mapper.Map<Extra,ExtraDto>(extra));
        }

        [HttpGet("{oid}")]
        public IActionResult Get(string oid)
        {
            var extra = _extraRepository.Find(x => x.Oid == new Guid(oid), y => y.Unit);
            if (extra == null)
                return NotFound();

            return Ok(_mapper.Map<Extra, ExtraDto>(extra));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var extras = _extraRepository.GetAll(x => x.Unit);
            
            return Ok(_mapper.Map<IEnumerable<Extra>, IEnumerable<ExtraDto>>(extras));
        }

        [HttpPut("{oid}")]
        public IActionResult Update(string oid, [FromBody] SaveExtraDto saveExtraDto)
        {
            var extraDb = _extraRepository.Find(x => x.Oid == new Guid(oid));
            extraDb.Name = saveExtraDto.Name;
            var unit = _unitRepository.Find(x => x.Oid == new Guid(saveExtraDto.UnitOid));
            if (unit == null)
                return NotFound("Unit not found");
            extraDb.Unit = unit;

            _extraRepository.Update(extraDb);

            _unitOfWork.Complete();
            return Ok(_mapper.Map<Extra,ExtraDto>(extraDb));
        }

        [HttpDelete("{oid}")]
        public IActionResult Remove(string oid)
        {
            extra = _extraRepository.Find(x => x.Oid == new Guid(oid));
            if (extra == null)
                return NotFound("Extra not found");

            _extraRepository.Remove(extra);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}