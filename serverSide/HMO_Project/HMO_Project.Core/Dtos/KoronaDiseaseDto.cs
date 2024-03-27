using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.Dtos
{
    public class KoronaDiseaseDto
    {
        public int Id { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public DateTime? RecoveryDate { get; set; }

        public int MemberId { get; set; }

    }
}
