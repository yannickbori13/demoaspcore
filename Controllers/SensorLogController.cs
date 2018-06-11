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
    [Route("api/SensorLog")]
    public class SensorLogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISensorLogRepository _sensorLogRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SensorLogController(
            IUnitOfWork unitOfWork,
            ISensorLogRepository sensorLogRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _sensorLogRepository = sensorLogRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public IActionResult CreateLog([FromBody] SaveSensorLogDto saveSensorLogDto)
        {
            var sensorLog = _mapper.Map<SensorLog>(saveSensorLogDto);
            sensorLog.DateTime = DateTime.Now;
            sensorLog.FromIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            _sensorLogRepository.Insert(sensorLog);
            _unitOfWork.Complete();
            //return Ok(_mapper.Map<SensorLogDto>(sensorLog));
            return Ok();
        }

        [HttpGet]
        public IActionResult GetLogs()
        {
            var sensorLogsDb = _sensorLogRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<SensorLogDto>>(sensorLogsDb));
        }
    }
}