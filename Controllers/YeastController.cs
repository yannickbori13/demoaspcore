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
    [Route("api/Yeast")]
    public class YeastController : Controller
    {
        private readonly IYeastRepository _yeastRepository;
        private readonly IUnitOfWork _unitOfWork;

        public YeastController(IYeastRepository yeastRepository, IUnitOfWork unitOfWork)
        {
            _yeastRepository = yeastRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Yeast yeast)
        {
            _yeastRepository.Insert(yeast);
            _unitOfWork.Complete();
            return Ok(yeast);
        }

        [HttpGet("{oid}")]
        public IActionResult Get(string oid)
        {
            var yeast = _yeastRepository.Find(x => x.Oid == new Guid(oid));
            if (yeast == null)
                return NotFound();

            return Ok(yeast);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_yeastRepository.GetAll());
        }

        [HttpPut("{oid}")]
        public IActionResult Update(string oid, [FromBody] Yeast yeast)
        {
            var yeastDb = _yeastRepository.Find(x => x.Oid == new Guid(oid));
            yeastDb.Name = yeast.Name;
            yeastDb.ProductNumber = yeast.ProductNumber;
            yeastDb.Link = yeast.Link;
            yeastDb.Vendor = yeast.Vendor;

            _yeastRepository.Update(yeastDb);

            _unitOfWork.Complete();
            return Ok(yeastDb);
        }

        [HttpDelete]
        public IActionResult Remove(string oid)
        {
            var yeast = _yeastRepository.Find(x => x.Oid == new Guid(oid));
            if (yeast == null)
                return NotFound();

            _yeastRepository.Remove(yeast);

            return Ok();
        }
    }
}