using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.Entities
{
    public class VaccineProducer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Vaccination> Vaccinations { get; set; }
    }
}
