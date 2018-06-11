using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Fermentable")]
    public class FermentableController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFermentableRepository _fermentableRepository;

        public FermentableController(
            IUnitOfWork unitOfWork, 
            IFermentableRepository fermentableRepository)
        {
            _unitOfWork = unitOfWork;
            _fermentableRepository = fermentableRepository;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Fermentable fermentable)
        {
            _fermentableRepository.Insert(fermentable);
            _unitOfWork.Complete();
            return Ok(fermentable);
        }

        [HttpGet("{oid}")]
        public IActionResult Get(string oid)
        {
            var fermentable = _fermentableRepository.Find(x=>x.Oid == new Guid(oid));
            if (fermentable == null)
                return NotFound();

            return Ok(fermentable);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            return Ok(_fermentableRepository.GetAll());
        }

        [HttpPut("{oid}")]
        public IActionResult Update(string oid, [FromBody] Fermentable fermentable)
        {
            var fermentableDb = _fermentableRepository.Find(x => x.Oid == new Guid(oid));
            fermentableDb.Name = fermentable.Name;
            fermentableDb.Description = fermentable.Description;
            fermentableDb.Link = fermentable.Link;
            fermentableDb.Vendor = fermentable.Vendor;
            
            _fermentableRepository.Update(fermentableDb);

            _unitOfWork.Complete();
            return Ok(fermentableDb);
        }

        [HttpDelete]
        public IActionResult Remove(string oid)
        {
            var fermentable = _fermentableRepository.Find(x => x.Oid == new Guid(oid));
            if (fermentable == null)
                return NotFound();

            _fermentableRepository.Remove(fermentable);

            return Ok();
        }
    }
}