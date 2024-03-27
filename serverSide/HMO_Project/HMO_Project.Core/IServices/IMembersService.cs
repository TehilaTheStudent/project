using HMO_Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.IServices
{
    public interface IMembersService
    {
        public Task<IEnumerable<Member>> GetAllAsync();

        public Task<Member> GetEmptyAsync(int id);
        public Task<Member> GetAsync(int id);


        public Task<Member> PostAsync(Member newMmeber);
        public  Task<int> CountNotVaccinatedAsync();
    }
}
