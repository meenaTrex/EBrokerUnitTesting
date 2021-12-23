using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryManagement.Interfaces
{
    public interface IEquityManager
    {
        TraderEquity GetEquity(int traderId, string company);
        Task RemoveEquity(TraderEquity equity);
        Task UpdateTraderEquity(TraderEquity equity);
        Task<int> AddTraderEquity(TraderData data);
    }
}
