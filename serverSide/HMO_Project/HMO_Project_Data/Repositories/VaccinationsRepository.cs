using AutoMapper.Execution;
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
    public class VaccinationsRepository : IVaccinationsRepository
    {
        private readonly DataContext _dataContext;
        public VaccinationsRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<IEnumerable<Vaccination>> GetByVaccineProducerIdAsync(int vaccineProducerId)
        {
            return await _dataContext.VaccinationsData.Where(v => v.VaccineProducerId == vaccineProducerId).Include(v=>v.VaccineProducer).ToListAsync() ;
        }
       
        public async Task<Vaccination> LatestOfmember(int memberId)
        {
            return await _dataContext.VaccinationsData.Where(v => v.MemberId == memberId)
          .OrderByDescending(v => v.NumberOfVaccination)
          .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Vaccination>> GetAllAsync()
        {
            return await _dataContext.VaccinationsData.Include(v => v.VaccineProducer).ToListAsync();
        }

        public async Task<Vaccination> GetAsync(int id)
        {
            return await _dataContext.VaccinationsData.Include(v => v.VaccineProducer).FirstOrDefaultAsync(v => v.Id == id);
        }
      
        public async Task<Vaccination> PostAsync(Vaccination newVaccination)
        {
            _dataContext.VaccinationsData.Add(newVaccination);
            await _dataContext.SaveChangesAsync();

            var added = await _dataContext.VaccinationsData.Include(v=>v.VaccineProducer).OrderByDescending(v => v.Id).FirstOrDefaultAsync();
            return added;
        }


    }
}
