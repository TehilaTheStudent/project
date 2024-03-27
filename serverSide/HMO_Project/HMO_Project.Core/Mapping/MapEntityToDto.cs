using AutoMapper;
using HMO_Project.Core.Dtos;
using HMO_Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.Mapping
{
    public class MapEntityToDto:Profile
    {
        public MapEntityToDto() 
        { 
            CreateMap<KoronaDisease,KoronaDiseaseDto>();
            CreateMap<KoronaDisease,KoronaDiseaseOfMemberDto>();
     //       CreateMap<Member,MemberDto>();
            CreateMap<Vaccination,VaccinationDto>();
            CreateMap<Vaccination,VaccinationOfMemberDto>();
            CreateMap<VaccineProducer,VaccineProducerDto>();
            CreateMap<Member, MemberDto>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom((src, dest, destMember, context) =>
            {
                if(src.FileData is null)
                {
                    return null;
                }
                var url = context.Items["Url"];

                var fullUrl = url + "" + src.Id + "/Image";
                //https://localhost:7095/HMO/Member/5/Image
                return fullUrl;
            }));
        }
    }
}
