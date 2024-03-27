using HMO_Project.Core.Entities;
using HMO_Project.Core.IRepositpries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project_Data.Repositories
{
    public class VaccineProducersRepository : IVaccineProducersRepository
    {
        private readonly DataContext _dataContext;
        public VaccineProducersRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<IEnumerable<VaccineProducer>> GetAllAsync()
        {
            return await _dataContext.VaccineProducersData.ToListAsync();
        }

        public async Task<VaccineProducer> GetAsync(int id)
        {
            return await _dataContext.VaccineProducersData.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<VaccineProducer> PostAsync(VaccineProducer newVaccineProducer)
        {
            _dataContext.VaccineProducersData.Add(newVaccineProducer);
            await _dataContext.SaveChangesAsync();

            return newVaccineProducer;
        }

    }
}
