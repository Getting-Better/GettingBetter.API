﻿using GettingBetter.API.GettingBetter_System.Domain.Models;

namespace GettingBetter.API.GettingBetter_System.Domain.Repositories
{


    public interface ICyberRepository
    {
        Task<IEnumerable<Cyber>> ListAsync();
        Task AddAsync(Cyber cyberId);

        Task<Cyber> FindByIdAsync(int cyberId);

       
        void Update(Cyber cyberId);
        void Remove(Cyber cyberId);
    }
}
