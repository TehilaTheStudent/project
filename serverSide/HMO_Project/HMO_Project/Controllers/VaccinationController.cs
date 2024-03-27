using AutoMapper;
using HMO_Project.Api.Models.PostModels;
using HMO_Project.Api.Validation;
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
    public class VaccinationController : ControllerBase
    {
        private readonly IValidationVaccination _validation;
        private readonly IVaccinationsService _service;
        private readonly IMapper _mapper;

        public VaccinationController(IVaccinationsService service, IMapper mapper,IValidationVaccination validation)
        {
            _validation = validation;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<VaccinationDto>>> Get(int vaccineProducerId)
        {
            var listVaccinationsTask = await _service.GetAllAsync(vaccineProducerId);
            List<VaccinationDto> vaccinationDtoList = _mapper.Map<IEnumerable<VaccinationDto>>(listVaccinationsTask).ToList();
            return Ok(vaccinationDtoList);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<VaccinationDto>> GetById(int id)
        {
            var vaccinationTask = await _service.GetAsync(id);
            if (vaccinationTask is null)
            {
                return NotFound();
            }
            var vaccinationDto = _mapper.Map<VaccinationDto>(vaccinationTask);
            return Ok(vaccinationDto);
        }

        [HttpPost]
        public async Task<ActionResult<VaccinationDto>> Post([FromBody] VaccinationPostModel newVaccinationPostModel)
        {
            var result = await _validation.PostVaccinationResult(newVaccinationPostModel);
            if (result is not null)
            {
                return result;
            }
            var vaccinationToAdd = _mapper.Map<Vaccination>(newVaccinationPostModel);
            var vaccinationToAddTask = await _service.PostAsync(vaccinationToAdd);
            var vaccinationDto = _mapper.Map<VaccinationDto>(vaccinationToAddTask);
            return CreatedAtAction(nameof(GetById), new { id = vaccinationDto.Id }, vaccinationDto);
        }


    }
}
