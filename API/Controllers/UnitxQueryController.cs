using API.Data;
using API.Models;
using API.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitxQueryController(AppDbContext _db, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UnitxDto>>> GetUnits()
        {
            IEnumerable<Unitx> unit = await _db.Unitxes.ToListAsync();
            return Ok(_mapper.Map<List<UnitxDto>>(unit));
        }
        [HttpGet("{id:int}", Name = "GetUnit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<UnitxDto>> GetUnitById(int id)
        {
            {
                if (id <= 0)
                    return BadRequest("Invalid ID");

                var unit = await _db.Unitxes.FirstOrDefaultAsync(p=> p.Id == id);

                if (unit == null)
                    return NotFound("Unit not found");

                return Ok(_mapper.Map<UnitxDto>(unit));

            }
        }
    }
}
