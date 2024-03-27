using HMO_Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.IRepositpries
{
    public interface IKoronaDiseasesRepository
    {
        public Task<IEnumerable<KoronaDisease>> GetAllAsync();

        public Task<int> CountForDayAsync(DateTime date);
        public Task<KoronaDisease> GetAsync(int id);


        public Task<KoronaDisease> PostAsync(KoronaDisease newKoronaDisease);
    }
}
