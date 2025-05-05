using API.Data;
using API.Models;
using API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitxQueryController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<UnitxDto> >GetUnits()
        {
            return Ok(UnitxDbContext.unitsList);
        }
        [HttpGet("{id:int}", Name = "GetUnit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<UnitxDto>? GetUnitById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var unit = UnitxDbContext.unitsList.FirstOrDefault(p=>p.Id == id);

            if (unit == null)
                return NotFound();

            return Ok(unit);
            
        }

    }
}
