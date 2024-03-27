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
    public class VaccineProducersService : IVaccineProducersService
    {
        private readonly IVaccineProducersRepository _repository;
        public VaccineProducersService(IVaccineProducersRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<VaccineProducer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<VaccineProducer> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<VaccineProducer> PostAsync(VaccineProducer newVaccineProducer)
        {
            return await _repository.PostAsync(newVaccineProducer);
        }


    }
}
