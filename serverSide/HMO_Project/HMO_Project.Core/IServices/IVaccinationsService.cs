using HMO_Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.IServices
{
    public interface IVaccinationsService
    {



        public Task<Vaccination> LatestOfmember(int memberId);
    
        public Task<IEnumerable<Vaccination>> GetAllAsync(int vaccineProducerId);


        public Task<Vaccination> GetAsync(int id);


        public Task<Vaccination> PostAsync(Vaccination newVaccination);
    }
}
