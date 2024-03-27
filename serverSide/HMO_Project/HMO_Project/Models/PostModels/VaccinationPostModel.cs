using HMO_Project.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMO_Project.Api.Models.PostModels
{
    public class VaccinationPostModel
    {
        public int NumberOfVaccination { get; set; }

        public int VaccineProducerId { get; set; }

        public int MemberId { get; set; }

        public DateTime RecieveDate { get; set; }
    }
}
