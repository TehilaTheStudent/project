using AutoMapper;
using HMO_Project.Api.Controllers;
using HMO_Project.Api.Models.PostModels;
using HMO_Project.Core.Entities;

namespace HMO_Project.Api.Mapping
{
    public class MapModelToEntity:Profile
    {
        public MapModelToEntity() 
        {
            CreateMap<KoronaDiseasePostModel, KoronaDisease>();

            CreateMap<MemberPostModel, Member>();

            CreateMap<VaccinationPostModel, Vaccination>();

            CreateMap<VaccineProducerPostModel, VaccineProducer>();

        }
    }
}
