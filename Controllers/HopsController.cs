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
    [Route("api/Hops")]
    public class HopsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHopsRepository _hopsRepository;

        public HopsController(IUnitOfWork unitOfWork, IHopsRepository hopsRepository)
        {
            _unitOfWork = unitOfWork;
            _hopsRepository = hopsRepository;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Hops hops)
        {
            _hopsRepository.Insert(hops);
            _unitOfWork.Complete();
            return Ok(hops);
        }

        [HttpGet("{oid}")]
        public IActionResult Get(string oid)
        {
            var hops = _hopsRepository.Find(x => x.Oid == new Guid(oid));
            if (hops == null)
                return NotFound();

            return Ok(hops);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_hopsRepository.GetAll());
        }

        [HttpPut("{oid}")]
        public IActionResult Update(string oid, [FromBody] Hops hops)
        {
            var hopsDb = _hopsRepository.Find(x => x.Oid == new Guid(oid));
            hopsDb.Name = hops.Name;
            hopsDb.Description = hops.Description;
            hopsDb.Link = hops.Link;
            hopsDb.Vendor = hops.Vendor;

            _hopsRepository.Update(hopsDb);

            _unitOfWork.Complete();
            return Ok(hopsDb);
        }

        [HttpDelete]
        public IActionResult Remove(string oid)
        {
            var hops = _hopsRepository.Find(x => x.Oid == new Guid(oid));
            if (hops == null)
                return NotFound();

            _hopsRepository.Remove(hops);

            return Ok();
        }
    }
}