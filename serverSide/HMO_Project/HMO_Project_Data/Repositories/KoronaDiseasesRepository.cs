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
    public class KoronaDiseasesRepository : IKoronaDiseasesRepository
    {
        private readonly DataContext _dataContext;
        public KoronaDiseasesRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<IEnumerable<KoronaDisease>> GetAllAsync()
        {
            return await _dataContext.KoronaDiseasesData.ToListAsync();
        }

        public async Task<KoronaDisease> GetAsync(int id)
        {
            return await _dataContext.KoronaDiseasesData.FirstOrDefaultAsync(k => k.Id == id);
        }

        public async Task<KoronaDisease> PostAsync(KoronaDisease newKoronaDisease)
        {
            //new korona to existing member:

            //1. get member
            var existingMember = await _dataContext.MembersData.FirstOrDefaultAsync(m => m.Id == newKoronaDisease.MemberId);
            //2. set korona to member
            existingMember.KoronaDisease = newKoronaDisease;

            _dataContext.MembersData.Update(existingMember);
            //3.add korona
            _dataContext.KoronaDiseasesData.Add(newKoronaDisease);
            //4.save
            await _dataContext.SaveChangesAsync();
            //5.set korona id to member
            existingMember.KoronaDiseaseId = newKoronaDisease.Id;
            //6.save 
            await _dataContext.SaveChangesAsync();

            return newKoronaDisease;
        }

      
        public async Task<int> CountForDayAsync(DateTime date)
        {
            int illPeopleCount = await _dataContext.KoronaDiseasesData
        .CountAsync(i => i.DiagnosisDate <= date && (i.RecoveryDate == null || i.RecoveryDate >= date));
            return illPeopleCount;
        }
    }
}
