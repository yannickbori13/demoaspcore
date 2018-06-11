using System;
using Microsoft.AspNetCore.Mvc;
using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/UseType")]
    public class UseTypeController : Controller
    {
        private readonly IUseTypeRepository _useTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UseTypeController(IUseTypeRepository useTypeRepository, IUnitOfWork unitOfWork)
        {
            _useTypeRepository = useTypeRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] UseType useType)
        {
            _useTypeRepository.Insert(useType);
            _unitOfWork.Complete();
            return Ok(useType);
        }

        [HttpGet("{oid}")]
        public IActionResult Get(string oid)
        {
            var useType = _useTypeRepository.Find(x => x.Oid == new Guid(oid));
            if (useType == null)
                return NotFound();

            return Ok(useType);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_useTypeRepository.GetAll());
        }

        [HttpPut("{oid}")]
        public IActionResult Update(string oid, [FromBody] UseType useType)
        {
            var useTypeDb = _useTypeRepository.Find(x => x.Oid == new Guid(oid));
            useTypeDb.Name = useType.Name;
            _useTypeRepository.Update(useTypeDb);

            _unitOfWork.Complete();
            return Ok(useTypeDb);
        }

        [HttpDelete]
        public IActionResult Remove(string oid)
        {
            var useType = _useTypeRepository.Find(x => x.Oid == new Guid(oid));
            if (useType == null)
                return NotFound();

            _useTypeRepository.Remove(useType);

            return Ok();
        }
    }
}