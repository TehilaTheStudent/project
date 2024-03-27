using AutoMapper.Execution;
using HMO_Project.Core.Entities;
using HMO_Project.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMO_Project.Api.Controllers
{
    [Route("HMO/[controller]")]
    [ApiController]
    public class FillDataController : ControllerBase
    {
        private readonly IKoronaDiseasesService _koronaDiseasesService;
        private readonly IMembersService _membersService;
        private readonly IVaccinationsService _vaccinationsService;
        private readonly IVaccineProducersService _vaccineProducerService;

        public FillDataController(  IKoronaDiseasesService koronaDiseasesService, IMembersService membersService, IVaccinationsService vaccinationsService, IVaccineProducersService vaccineProducerService)
        {
            _koronaDiseasesService = koronaDiseasesService;
            _membersService = membersService;
            _vaccinationsService = vaccinationsService;
           _vaccineProducerService = vaccineProducerService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            VaccineProducer vaccineProducer1 = new VaccineProducer { Name = "producer 1" };
            VaccineProducer vaccineProducer2 = new VaccineProducer { Name = "producer 2" };
            await _vaccineProducerService.PostAsync(vaccineProducer1);
            await _vaccineProducerService.PostAsync(vaccineProducer2);
            Core.Entities.Member member1 = new Core.Entities.Member
            {
                IdNumber = "111222333",
                FullName = "Tehila Aharonovich",
                City = "Bney Brack",
                BirthDate = new DateTime(2003, 11, 11),
                HouseNumber = 24,
                MobilePhoneNumber = "0556725852",
                PhoneNumber = "036197683",
                Street = "harav kuk"

            };
            Core.Entities.Member member2 = new Core.Entities.Member
            {
                IdNumber = "111222333",
                FullName = "Ayala Elchadad",
                City = "Bney Brack",
                BirthDate = new DateTime(2003, 12, 3),
                HouseNumber = 31,
                MobilePhoneNumber = "0556725852",
                PhoneNumber = "036197683",
                Street = "rabi akiva"

            };
            Core.Entities.Member member3 = new Core.Entities.Member
            {
                IdNumber = "111222333",
                FullName = "Shoshi fredman",
                City = "Bney Brack",
                BirthDate = new DateTime(2004, 6, 21),
                HouseNumber = 13,
                MobilePhoneNumber = "0556725852",
                PhoneNumber = "036197683",
                Street = "pardo"

            };
            await _membersService.PostAsync(member1);
            await _membersService.PostAsync(member2);
            await _membersService.PostAsync(member3);
            Vaccination vaccination1 = new Vaccination
            {
                MemberId = member1.Id,
                NumberOfVaccination = 1,
                VaccineProducerId = vaccineProducer1.Id,
                RecieveDate = new DateTime(2010, 10, 10),
            };
            Vaccination vaccination2 = new Vaccination
            {
                MemberId = member1.Id,
                NumberOfVaccination = 2,
                VaccineProducerId = vaccineProducer2.Id,
                RecieveDate = new DateTime(2010, 10, 10),
            };
            Vaccination vaccination3 = new Vaccination
            {
                MemberId = member2.Id,
                NumberOfVaccination = 1,
                VaccineProducerId = vaccineProducer1.Id,
                RecieveDate = new DateTime(2010, 10, 10),
            };
            await _vaccinationsService.PostAsync(vaccination1);
            await _vaccinationsService.PostAsync(vaccination2);
            await _vaccinationsService.PostAsync(vaccination3);
            KoronaDisease koronaDisease1 = new KoronaDisease
            {
                MemberId = member1.Id,
                DiagnosisDate = new DateTime(2024, 2, 2),
                RecoveryDate = new DateTime(2024, 3, 3)
            };
            KoronaDisease koronaDisease2 = new KoronaDisease
            {
                MemberId = member3.Id,
                DiagnosisDate = new DateTime(2024, 10, 1),
                RecoveryDate = new DateTime(2024, 10, 2)
            };
            await _koronaDiseasesService.PostAsync(koronaDisease1);
            await _koronaDiseasesService.PostAsync(koronaDisease2);
            return Ok("added: 3 members, 2 korona diseases, 3 vaccinations and 2 vaccine producers");
        }

       


    }
}
