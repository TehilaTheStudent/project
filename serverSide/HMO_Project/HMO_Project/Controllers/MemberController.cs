using AutoMapper;
using HMO_Project.Api.Models.PostModels;
using HMO_Project.Api.Validation;
using HMO_Project.Core.Dtos;
using HMO_Project.Core.Entities;
using HMO_Project.Core.IServices;
using HMO_Project_Data.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO_Project.Api.Controllers
{
    [Route("HMO/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        private readonly IMembersService _service;
        private readonly IMapper _mapper;

        public MemberController(IMembersService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MemberDto>>> Get()
        {
            var listMembersTask = await _service.GetAllAsync();

            var url = MakeUrl();
            List<MemberDto> memberDtoList = _mapper.Map<IEnumerable<MemberDto>>(listMembersTask, opt => opt.Items["Url"] = url).ToList();
            return Ok(memberDtoList);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetById(int id)
        {
            var memberTask = await _service.GetAsync(id);
            if (memberTask is null)
            {
                return NotFound();
            }
            var url = MakeUrl();

            var memberDto = _mapper.Map<MemberDto>(memberTask, opt => opt.Items["Url"] = url);
            return Ok(memberDto);
        }
        [HttpPost]
        public async Task<ActionResult<MemberDto>> Post([FromForm] MemberPostModel newMemberPostModel)
        {
            string? message = ValidationData.ValidMemberPostModel(newMemberPostModel);
            if (message is not null)
                return BadRequest(message);

            var memberToAdd = _mapper.Map<Member>(newMemberPostModel);
            if (newMemberPostModel.ImageFile is not null)
            {
                try
                {
                    using (var stream = new MemoryStream())
                    {
                        //here, get from file bytes array
                        newMemberPostModel.ImageFile.CopyTo(stream);//file->stream
                        memberToAdd.FileData = stream.ToArray();//stream->Byte []
                        memberToAdd.FileType = newMemberPostModel.ImageFile.ContentType;

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            var memberToAddTask = await _service.PostAsync(memberToAdd);

            var url = MakeUrl();

            var memberDto = _mapper.Map<MemberDto>(memberToAddTask, opt => opt.Items["Url"] = url);

            return CreatedAtAction(nameof(GetById), new { id = memberDto.Id }, memberDto);
        }
        [HttpGet("{id}/Image")]
        public async Task<IActionResult> GetFileById(int id)
        {
            var member = await _service.GetAsync(id);
            if (member is null)
            {
                return NotFound("member not found");
            }
            if (member.FileData is not null)
            {
                var file = File(member.FileData, member.FileType);//iformfile->bytes+type=file!
                return file;
            }
            else
            {
                Response.Headers.Add("X-Message", "Member exists, but image is null");
                return NoContent();
            }
        }
        [HttpGet("CountNotVaccinated")]
        public async Task<IActionResult> CountNotVaccinated()
        {
            var num= await _service.CountNotVaccinatedAsync();
            return Ok(new {countNotVaccinated=num});
        }
        private string MakeUrl()
        {
            var request = HttpContext.Request;
            var scheme = request.Scheme;
            var host = request.Host.Host;
            var port = request.Host.Port;

            var url = $"{scheme}://{host}:{port}/HMO/{HttpContext.Request.RouteValues["controller"]}/";//{memberToAdd.Id}/Image         }
            return url;
        }
    }
}
