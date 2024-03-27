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
    public class KoronaDiseasesService : IKoronaDiseasesService
    {
        private readonly IKoronaDiseasesRepository _repository;
        public KoronaDiseasesService(IKoronaDiseasesRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<KoronaDisease>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        
        public async Task<KoronaDisease> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<KoronaDisease> PostAsync(KoronaDisease newKoronaDisease)
        {
            return await _repository.PostAsync(newKoronaDisease);
        }

        public async Task<Dictionary<DateTime, int>> CountIllEachDayAsync()
        {
            List<DateTime> dates = new List<DateTime>();

            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastMonth = firstDayOfMonth.AddMonths(-1);//first day of last month

            int daysInLastMonth = DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month);

            for (int day = 1; day <= daysInLastMonth; day++)
            {
                DateTime date = new DateTime(lastMonth.Year, lastMonth.Month, day);//create date obj for each wanted day
                dates.Add(date);
            }
            Dictionary<DateTime, int> dateCount = new Dictionary<DateTime, int>();

            foreach (var date in dates)//for each date in the list
            {
                int count = await _repository.CountForDayAsync(date);
                dateCount[date] = count;//add key && value
            }

            return dateCount;
        }



    }
}
