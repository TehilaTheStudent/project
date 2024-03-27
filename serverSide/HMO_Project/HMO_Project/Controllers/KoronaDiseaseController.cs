
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
    public class KoronaDiseaseController : ControllerBase
    {
        private readonly IValidationKoronaDisease _validation;
        private readonly IKoronaDiseasesService _service;
        private readonly IMapper _mapper;

        public KoronaDiseaseController(IKoronaDiseasesService service, IMapper mapper, IValidationKoronaDisease validation)
        {
            _service = service;
            _mapper = mapper;
            _validation = validation;
        }

        [HttpGet]
        public async Task<ActionResult<List<KoronaDiseaseDto>>> Get()
        {
            var listKoronaDiseasesTask = await _service.GetAllAsync();
            List<KoronaDiseaseDto> koronaDiseaseDtoList = _mapper.Map<IEnumerable<KoronaDiseaseDto>>(listKoronaDiseasesTask).ToList();
            return Ok(koronaDiseaseDtoList);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<KoronaDiseaseDto>> GetById(int id)
        {
            var koronaDiseaseTask = await _service.GetAsync(id);
            if(koronaDiseaseTask is null)
            {
                return NotFound();
            }
            var koronaDiseaseDto = _mapper.Map<KoronaDiseaseDto>(koronaDiseaseTask);
            return Ok(koronaDiseaseDto);
        }

        [HttpPost]
        public async Task<ActionResult<KoronaDiseaseDto>> Post([FromBody] KoronaDiseasePostModel newKoronaDiseasePostModel)
        {
            string message = ValidationData.ValidKoronaDiseasePostModel(newKoronaDiseasePostModel);
            if (message is not null)
                return BadRequest(message);
            var result =await _validation.PostKoronaDiseaseResult(newKoronaDiseasePostModel);
            if(result is not null)
            {
                return result;
            }
            var koronaDiseaseToAdd = _mapper.Map<KoronaDisease>(newKoronaDiseasePostModel);
            var koronaDiseaseToAddTask = await _service.PostAsync(koronaDiseaseToAdd);
            var koronaDiseaseDto = _mapper.Map<KoronaDiseaseDto>(koronaDiseaseToAddTask);
            return CreatedAtAction(nameof(GetById), new { id = koronaDiseaseDto.Id }, koronaDiseaseDto);
        }

        

        [HttpGet("CountIllEachDay")]
        public async Task<ActionResult<Dictionary<DateTime,int>>> CountIllEachDay()
        {
            var dict=await _service.CountIllEachDayAsync();
            return Ok(dict);
        }
    }


}

