﻿using Derivco.GameRoulette.Application.Models.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Bettor>> GetBettors(); //Retrieve all bettors in the system
        Task<Bettor> GetBettor(string bettorId); //Get a single bettor in the system 
        public string BettorId { get; }
    }
}
