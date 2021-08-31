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
    [ApiController]
    [Route("api/buildings")]
    public class BuildingsController : ControllerBase
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

        public async Task<ActionResult<bool>> GetStatusBuilding(int buildingid)
        {
            var result = await _service.GetStatus(buildingId);
            return Ok(result);
        }
        
    }
}
