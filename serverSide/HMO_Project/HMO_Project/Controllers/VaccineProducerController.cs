using AutoMapper;
using HMO_Project.Api.Models.PostModels;
using HMO_Project.Core.Dtos;
using HMO_Project.Core.Entities;
using HMO_Project.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO_Project.Api.Controllers
{
    [Route("HMO/[controller]")]
    [ApiController]
    public class VaccineProducerController : ControllerBase
    {
        private readonly IVaccineProducersService _service;
        private readonly IMapper _mapper;

        public VaccineProducerController(IVaccineProducersService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<VaccineProducerDto>>> Get()
        {
            var listVaccineProducersTask = await _service.GetAllAsync();
            List<VaccineProducerDto> vaccineProducerDtoList = _mapper.Map<IEnumerable<VaccineProducerDto>>(listVaccineProducersTask).ToList();
            return Ok(vaccineProducerDtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VaccineProducerDto>> GetById(int id)
        {
            var vaccineProducerTask = await _service.GetAsync(id);
            if (vaccineProducerTask is null)
            {
                return NotFound();
            }
            var vaccineProducerDto = _mapper.Map<VaccineProducerDto>(vaccineProducerTask);
            return Ok(vaccineProducerDto);
        }
        [HttpPost]
        public async Task<ActionResult<VaccineProducerDto>> Post([FromBody] VaccineProducerPostModel newVaccineProducerPostModel)
        {
          
            var vaccineProducerToAdd = _mapper.Map<VaccineProducer>(newVaccineProducerPostModel);
            var vaccineProducerToAddTask = await _service.PostAsync(vaccineProducerToAdd);
            var vaccineProducerDto = _mapper.Map<VaccineProducerDto>(vaccineProducerToAddTask);
            return CreatedAtAction(nameof(GetById), new { id = vaccineProducerDto.Id }, vaccineProducerDto);


        }


    }
}
