using HMO_Project.Api.Models.PostModels;
using HMO_Project.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HMO_Project.Api.Validation
{
    public class ValidationVacccination:IValidationVaccination
    {
        private readonly IVaccinationsService _vaccinationsService;
        private readonly IMembersService _membersService;
        private readonly IVaccineProducersService _vaccineProducersService;
        public  ValidationVacccination(IMembersService membersService, IVaccinationsService vaccinationsService, IVaccineProducersService vaccineProducerService)
        {
            _membersService = membersService;
            _vaccinationsService = vaccinationsService;
            _vaccineProducersService = vaccineProducerService;
        }
        public async Task<ObjectResult?> PostVaccinationResult(VaccinationPostModel vaccinationPost)
        {
            var existsMember = await _membersService.GetEmptyAsync(vaccinationPost.MemberId);
            var existsProducer = await _vaccineProducersService.GetAsync(vaccinationPost.VaccineProducerId);
            if (existsMember is null)
            {
                return new NotFoundObjectResult("member not found");
            }
            if (existsProducer is null)
            {
                return new NotFoundObjectResult("vaccine producer not found");
            }
            if (vaccinationPost.RecieveDate < existsMember.BirthDate)
            {
                return new BadRequestObjectResult("vaccination recieve date cant be earlier than member birth date");
            }
            var latestOfMember = await _vaccinationsService.LatestOfmember(vaccinationPost.MemberId);
            if (latestOfMember is not null)
            {
                if (vaccinationPost.NumberOfVaccination + 1 != latestOfMember.NumberOfVaccination || vaccinationPost.NumberOfVaccination > 4)
                {
                    return new BadRequestObjectResult("wrong number of vaccination");
                }
                if (vaccinationPost.RecieveDate < latestOfMember.RecieveDate)
                {
                    return new BadRequestObjectResult("recieve date cant be earlier than the latest vaccination of this member");
                }
            }

            return null;
        }



    }
}
