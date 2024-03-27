using HMO_Project.Core.Entities;
using HMO_Project.Core.IRepositpries;
using HMO_Project.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Service.Services
{
    public class VaccinationsService:IVaccinationsService
    {
        private readonly IVaccinationsRepository _repository;
        public VaccinationsService(IVaccinationsRepository repository)
        {
            this._repository = repository;
        }
   

        public async Task<Vaccination> LatestOfmember(int memberId)
        {
            return await _repository.LatestOfmember(memberId);
        }
        public async Task<IEnumerable<Vaccination>> GetAllAsync(int vaccineProducerId)
        {
            if (vaccineProducerId > 0)
            {
                return await _repository.GetByVaccineProducerIdAsync(vaccineProducerId);
            }
            return await _repository.GetAllAsync();
        }

        public async Task<Vaccination> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Vaccination> PostAsync(Vaccination newVaccination)
        {
            return await _repository.PostAsync(newVaccination);
        }



    }
}
