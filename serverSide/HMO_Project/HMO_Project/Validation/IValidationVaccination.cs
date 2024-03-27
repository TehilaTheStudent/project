using HMO_Project.Api.Models.PostModels;
using Microsoft.AspNetCore.Mvc;

namespace HMO_Project.Api.Validation
{
    public interface IValidationVaccination
    {
        public  Task<ObjectResult?> PostVaccinationResult(VaccinationPostModel vaccinationPost);

    }
}
