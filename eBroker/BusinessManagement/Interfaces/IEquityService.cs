using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Interfaces
{
    public interface IEquityService
    {
        Task<bool> SellEquity(TraderData data);
        Task<int> BuyEquity(TraderData data);
        Task<bool> AddFunds(int personId, double fundAmount);
    }
}
