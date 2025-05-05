using API.Data;
using API.Models;
using API.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitxCommandController(AppDbContext _db, IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<ActionResult<UnitxDto>> CreateUnit(UnitxCreateDto dto)
        {
            if (dto is null)
            {
                return BadRequest(dto);
            }
            if(await _db.Unitxes.FirstOrDefaultAsync(u => u.Name.ToLower() == dto.Name.ToLower()) != null)
            {
                return BadRequest("Unit already Exists");
            }
            Unitx unit = _mapper.Map<Unitx>(dto);
            
            _db.Unitxes.Add(unit);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetUnit" ,new{ unit.Id}, unit);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UnitxDto>> DeleteUnit(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id");
            var unitx = await _db.Unitxes.FirstOrDefaultAsync(u => u.Id==id);
            if (unitx == null)
                return NotFound("Id not found");

            _db.Unitxes.Remove(unitx);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUnit(int id, UnitxUpdateDto dto)
        {
            if (dto is null || id != dto.Id)
                return BadRequest("Invalid Id");

            Unitx unit = _mapper.Map<Unitx>(dto);
            _db.Unitxes.Update(unit);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
