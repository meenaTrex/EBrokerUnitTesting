using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryManagement.Interfaces
{
    public interface IFundManager
    {
        Task<bool> addFunds(double funds, int traderId);
        Task<bool> removeFunds(double funds, int traderId);
        double GetFunds(int traderId);
    }
}
