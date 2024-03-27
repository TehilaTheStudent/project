using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.Entities
{
    public class KoronaDisease
    {
        public int Id { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime DiagnosisDate { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime? RecoveryDate { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
