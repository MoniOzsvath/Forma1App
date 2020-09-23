using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Forma1App.Controllers.Dtos;
using Forma1App.Models;
using Forma1App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Forma1App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Forma1TeamController : ControllerBase
    {
        private readonly IForma1TeamRepository _forma1TeamRepository;
        private readonly IMapper _mapper;

        public Forma1TeamController(
            IForma1TeamRepository forma1TeamRepository,
            IMapper mapper)
        {
            _forma1TeamRepository = forma1TeamRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var teams = await _forma1TeamRepository.GetAllAsync();
            var teamsReturn = _mapper.Map<IEnumerable<Forma1TeamReturnDto>>(teams);
            return Ok(teamsReturn);
        }

        [HttpGet("{id}", Name=nameof(GetAsync))]
        public async Task<IActionResult> GetAsync(long id)
        {
            var team = await _forma1TeamRepository.GetAsync(id);
            var teamReturn = _mapper.Map<Forma1TeamReturnDto>(team);
            return Ok(teamReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Forma1TeamAddDto forma1TeamAdd)
        {
            var entityToSave = _mapper.Map<Forma1TeamEntity>(forma1TeamAdd);
            var team = await _forma1TeamRepository.AddAsync(entityToSave);
            var teamReturn = _mapper.Map<Forma1TeamReturnDto>(team);
            return CreatedAtRoute(nameof(GetAsync), new { id = teamReturn.Id }, teamReturn);

         //   return Ok(teamReturn);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Forma1TeamUpdateDto forma1TeamUpdate)
        {
            var entityToSave = _mapper.Map<Forma1TeamEntity>(forma1TeamUpdate);
            var team = await _forma1TeamRepository.UpdateAsync(entityToSave);
            var teamReturn = _mapper.Map<Forma1TeamReturnDto>(team);
            return Ok(teamReturn);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _forma1TeamRepository.DeleteAsync(id);  
            return NoContent();
        }
    }
}
