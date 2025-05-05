using API.Data;
using API.Models;
using API.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitxCommandController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UnitxDto> CreateUnit(UnitxDto dto)
        {
            if (dto is null || dto.Id == 0)
            {
                return BadRequest(dto);
            }
            if(UnitxDbContext.unitsList.Any(p=>p.Id == dto.Id))
                return BadRequest("This Id in on the list");
                
            UnitxDbContext.unitsList.Add(dto);
            return CreatedAtRoute("GetUnit" ,new{dto.Id}, dto);
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UnitxDto>? DeleteUnit(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id");
            var unitx = UnitxDbContext.unitsList.FirstOrDefault(u => u.Id==id);
            if (unitx == null)
                return NotFound("Id not found");

            UnitxDbContext.unitsList.Remove(unitx);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<UnitxDto> UpdateUnit(int id, UnitxDto unitx)
        {
            if (unitx is null || id != unitx.Id)
                return BadRequest("Invalid Id");
            var unit = UnitxDbContext.unitsList.FirstOrDefault(p => p.Id == id);
            if (unit == null)
                return NotFound("there is no such unit");
            unit.Name = unitx.Name ;
            unit.Ocupancy = unitx.Ocupancy;
            unit.Area = unitx.Area;
            return NoContent();
        }
        //testing patch
        //[HttpPatch("{id:int}")]
        //public ActionResult<UnitxDto> PartialUpdate(int id, JsonPatchDocument<UnitxDto> patch)
        //{
        //    if (patch is null || id ==0)
        //        return BadRequest("Invalid Id");
        //    var unit = UnitxDbContext.unitsList.FirstOrDefault(u => u.Id == id);
        //    if (unit == null)
        //        return NotFound();
        //    patch.ApplyTo(unit);
        //    return NoContent();
        //}

    }
}
