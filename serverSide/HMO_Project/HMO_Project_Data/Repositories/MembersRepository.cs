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
    public class MembersRepository : IMembersRepository
    {
        private readonly DataContext _dataContext;
        public MembersRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            var all=await  _dataContext.MembersData.Include(m => m.KoronaDisease).Include(m=>m.Vaccinations).ThenInclude(v=>v.VaccineProducer).ToListAsync();
            return all;
        }

        public async Task<Member> GetAsync(int id)
        {
            return await _dataContext.MembersData.Include(m => m.KoronaDisease).Include(m=>m.Vaccinations).ThenInclude(v => v.VaccineProducer).FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<Member> GetEmptyAsync(int id)
        {
            return await _dataContext.MembersData.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<Member> PostAsync(Member newMember)
        {
            _dataContext.MembersData.Add(newMember);
            await _dataContext.SaveChangesAsync();

            return newMember;
        }

        public async Task<int> CountNotVaccinatedAsync()
        {
            return await _dataContext.MembersData.CountAsync(v => v.Vaccinations.Count()==0);

        }


    }
}
