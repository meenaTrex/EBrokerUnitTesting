using RepositoryManagement.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace RepositoryManagement.Services
{
    public class FundManager : IFundManager
    {
        private TraderContext _context;

        public FundManager(TraderContext context)
        {
            _context = context;
        }

        public double GetFunds(int traderId)
        {
            var traderFunds = _context.Funds.Where(x => x.TraderId == traderId).FirstOrDefault();
            return traderFunds.Amount;
        }

        public Fund GetTraderFunds(int traderId)
        {
            var traderFunds = _context.Funds.Where(x => x.TraderId == traderId).FirstOrDefault();
            _context.ChangeTracker.Clear();
            return traderFunds;
        }
        public async Task<bool> addFunds(double funds, int traderId)
        {
            var data = GetTraderFunds(traderId);
            _context.Funds.Update(new Fund() {Id = data.Id, TraderId = traderId, Amount = data.Amount + funds });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> removeFunds(double funds, int traderId)
        {
            var data = GetTraderFunds(traderId);
            _context.Funds.Update(new Fund() { Id = data.Id, TraderId = traderId, Amount = data.Amount - funds });
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
