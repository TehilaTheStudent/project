using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.Entities
{
    public class Vaccination
    {
        public int Id { get; set; }
        public int NumberOfVaccination { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime  RecieveDate { get; set; }
        public int VaccineProducerId { get; set; }
        public VaccineProducer VaccineProducer { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
