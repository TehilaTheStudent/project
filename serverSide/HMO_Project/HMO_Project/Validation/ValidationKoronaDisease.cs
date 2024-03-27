using HMO_Project.Api.Controllers;
using HMO_Project.Api.Models.PostModels;
using HMO_Project.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HMO_Project.Api.Validation
{
    public class ValidationKoronaDisease:IValidationKoronaDisease
    {
        private readonly IMembersService _memberService;

        public ValidationKoronaDisease(IKoronaDiseasesService koronaDiseaseService, IMembersService memberService, IVaccinationsService vaccinationService)
        {
            _memberService = memberService;

        }
        
        public  async Task<ObjectResult?> PostKoronaDiseaseResult(KoronaDiseasePostModel koronaDisease)
        {
            var existsMember = await _memberService.GetEmptyAsync(koronaDisease.MemberId);
            if (existsMember is null)
            {
                return new NotFoundObjectResult("member not found");
            }
            if(existsMember.KoronaDiseaseId is not null)
            {
                return new ConflictObjectResult("member has korona disease already");
            }
            if (existsMember.BirthDate > koronaDisease.DiagnosisDate)
            {
                return new BadRequestObjectResult("diagnosis date cant be earlier than member birthdate");
            }
            
            return null;
        }

       

       }

}
