using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Units")]
    public class UnitsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitRepository _unitRepository;

        public UnitsController(IUnitOfWork unitOfWork,IUnitRepository unitRepository)
        {
            _unitOfWork = unitOfWork;
            _unitRepository = unitRepository;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Unit unit)
        {
            _unitRepository.Insert(unit);
            _unitOfWork.Complete();
            return Ok(unit);
        }

        [HttpGet("{oid}")]
        public IActionResult Get(string oid)
        {
            var unit = _unitRepository.Find(x => x.Oid == new Guid(oid));
            if (unit == null)
                return NotFound();

            return Ok(unit);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_unitRepository.GetAll());
        }

        [HttpPut("{oid}")]
        public IActionResult Update(string oid, [FromBody] Unit unit)
        {
            var unitDb = _unitRepository.Find(x => x.Oid == new Guid(oid));
            unitDb.Name = unit.Name;
            _unitRepository.Update(unitDb);

            _unitOfWork.Complete();
            return Ok(unitDb);
        }

        [HttpDelete]
        public IActionResult Remove(string oid)
        {
            var unit = _unitRepository.Find(x => x.Oid == new Guid(oid));
            if (unit == null)
                return NotFound();

            _unitRepository.Remove(unit);

            return Ok();
        }
    }
}