using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdNumber { get; set; }
        public byte[]? FileData { get; set; }//this is the file-as saved in table
        public string? FileType { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public int? KoronaDiseaseId { get; set; }
        public KoronaDisease KoronaDisease { get; set; }
        public List<Vaccination> Vaccinations { get; set; }
    }
}
