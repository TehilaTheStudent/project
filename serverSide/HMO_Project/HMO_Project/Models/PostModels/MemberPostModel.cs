using HMO_Project.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMO_Project.Api.Models.PostModels
{
    public class MemberPostModel
    {
        public string FullName { get; set; }
        public string IdNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public IFormFile? ImageFile { get; set; }
        //1 no korona
        //2 add new korona
        //3 update dates in korona

    }
}
