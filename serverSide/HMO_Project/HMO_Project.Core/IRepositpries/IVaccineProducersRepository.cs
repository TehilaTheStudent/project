﻿using HMO_Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project.Core.IRepositpries
{
    public interface IVaccineProducersRepository
    {
        public Task<IEnumerable<VaccineProducer>> GetAllAsync();


        public Task<VaccineProducer> GetAsync(int id);


        public Task<VaccineProducer> PostAsync(VaccineProducer newVaccineProducer);
    }
}
