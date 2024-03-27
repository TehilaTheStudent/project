using HMO_Project.Api.Models.PostModels;
using Microsoft.AspNetCore.Mvc;

namespace HMO_Project.Api.Validation
{
    public interface IValidationKoronaDisease
    {
        public Task<ObjectResult?> PostKoronaDiseaseResult(KoronaDiseasePostModel koronaDisease);
    }
}
