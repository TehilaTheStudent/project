using HMO_Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdNumber { get; set; }
        public string? ImageUrl { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public KoronaDiseaseOfMemberDto KoronaDisease { get; set; }
        public List<VaccinationOfMemberDto> Vaccinations { get; set; }
    }
}
