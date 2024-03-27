using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMO_Project.Api.Models.PostModels
{
    public class KoronaDiseasePostModel
    {

        public DateTime DiagnosisDate { get; set; }

        public DateTime? RecoveryDate { get; set; }
        public int MemberId { get; set; }
    }
}
