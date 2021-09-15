using AutoMapper;
using Catering.API.Dtos.Buildings;
using Catering.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Controllers
{
    public class BuildingsController : BaseApiController
    {
        private readonly IBuildingService _service;
        private readonly IMapper _mapper;

        public BuildingsController(IBuildingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("freeBuildings")]
        public async Task<ActionResult<IEnumerable<BuildingDto>>> GetFreeBuildings()
        {
            var buildings = await _service.GetFreeBuildings();
            return Ok(_mapper.Map<IEnumerable<BuildingDto>>(buildings));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var building = await _service.GetById(id);
            return Ok(_mapper.Map<BuildingDto>(building));
        }
    }
}
