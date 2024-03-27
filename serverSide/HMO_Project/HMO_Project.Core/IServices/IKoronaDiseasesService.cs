using HMO_Project.Core.Entities;
using HMO_Project.Core.IRepositpries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.IServices
{
    public interface IKoronaDiseasesService
    {
        public  Task<IEnumerable<KoronaDisease>> GetAllAsync();


        public  Task<KoronaDisease> GetAsync(int id);

        public Task<Dictionary<DateTime, int>> CountIllEachDayAsync();

        public Task<KoronaDisease> PostAsync(KoronaDisease newKoronaDisease);
     
    }
}
