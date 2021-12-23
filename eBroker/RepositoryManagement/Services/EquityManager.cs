using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Shared.Models;
using RepositoryManagement.Interfaces;

namespace RepositoryManagement.Services
{
    public class EquityManager : IEquityManager
    {
        private TraderContext _context;

        public EquityManager(TraderContext context)
        {
            _context = context;
        }

        public TraderEquity GetEquity(int traderId, string company)
        {
            var data = _context.TraderEquities.Where(x => x.TraderId == traderId && x.CompanyName == company).FirstOrDefault();
            return data;
        }

        public async Task RemoveEquity(TraderEquity equity)
        {
            _context.TraderEquities.Remove(equity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTraderEquity(TraderEquity equity)
        {
            _context.TraderEquities.Update(equity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> AddTraderEquity(TraderData data)
        {
            var result = _context.TraderEquities.Add(new TraderEquity() { TraderId = data.TraderId, CompanyName = data.CompanyName, Amount = data.Amount });
            await _context.SaveChangesAsync();
            return result.Entity.TraderEquityId;
        }
    }
}
