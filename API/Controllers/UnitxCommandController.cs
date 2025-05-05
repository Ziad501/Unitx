using API.Data;
using API.Models;
using API.Models.Dto;
using API.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitxCommandController : ControllerBase
    {
        private readonly IQueryRepository<Unitx> _query;
        private readonly ICommandRepository<Unitx> _command;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public UnitxCommandController(IQueryRepository<Unitx> query, ICommandRepository<Unitx> command, IMapper mapper)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            this._response = new APIResponse();
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<ActionResult<APIResponse>> CreateUnit(UnitxCreateDto dto)
        {
            try
            {
                if (dto is null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                if (await _query.GetAsync(u => u.Name.ToLower() == dto.Name.ToLower()) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                
                Unitx unit = _mapper.Map<Unitx>(dto);
                unit.CreatedAt= DateTime.UtcNow;
                await _command.CreateAsync(unit);
                await _command.SaveAsync();
                _response.Result = _mapper.Map<UnitxCreateDto>(unit);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                
                return CreatedAtRoute("GetUnit", new { unit.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteUnit(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid Id");
                }
                var unitx = await _query.GetAsync(u => u.Id == id);
                if (unitx == null)
                    return NotFound("Id not found");

                await _command.DeleteAsync(unitx);
                await _command.SaveAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateUnit(int id, UnitxUpdateDto dto)
        {
            try
            {
                if (dto is null || id != dto.Id)
                    return BadRequest("Invalid Id");

                dto.UpdatedAt = DateTime.Now;
                Unitx unit = _mapper.Map<Unitx>(dto);
                await _command.UpdateAsync(unit);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
