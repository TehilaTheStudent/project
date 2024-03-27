using HMO_Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.Dtos
{
    public class VaccinationOfMemberDto
    {
        public int Id { get; set; }
        public int NumberOfVaccination { get; set; }
        public DateTime RecieveDate { get; set; }
        public VaccineProducerDto VaccineProducer { get; set; }
    }
}
