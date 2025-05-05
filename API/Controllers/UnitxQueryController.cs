using API.Data;
using API.Models;
using API.Models.Dto;
using API.Repository.IRepository;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitxQueryController : ControllerBase
    {
        private readonly IQueryRepository<Unitx> _query;
        private readonly IMapper? _mapper;
        protected APIResponse _response;
        public UnitxQueryController(IQueryRepository<Unitx> query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
            this._response = new APIResponse();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetUnits()
        {
            try
            {
                IEnumerable<Unitx> unit = await _query.GetAllAsync();
                _response.Result = _mapper.Map<List<UnitxDto>>(unit);
                _response.StatusCode = HttpStatusCode.OK;
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
        [HttpGet("{id:int}", Name = "GetUnit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> GetUnitById(int id)
        {
            try
            {

                if (id <= 0)
                    return BadRequest("Invalid ID");

                var unit = await _query.GetAsync(p => p.Id == id);

                if (unit == null)
                    return NotFound("Unit not found");
                _response.Result = _mapper.Map<UnitxDto>(unit);
                _response.StatusCode = HttpStatusCode.OK;
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
