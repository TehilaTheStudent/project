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
    public class MembersService : IMembersService
    {
        private readonly IMembersRepository _repository;
        public MembersService(IMembersRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Member> GetEmptyAsync(int id)
        {
            return await _repository.GetEmptyAsync(id);
        }
        public async Task<Member> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Member> PostAsync(Member newMember)
        {
            return await _repository.PostAsync(newMember);
        }
        public async Task<int> CountNotVaccinatedAsync()
        {
            return await _repository.CountNotVaccinatedAsync();
        }



    }
}
