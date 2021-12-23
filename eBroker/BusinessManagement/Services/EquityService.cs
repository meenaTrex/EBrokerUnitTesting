using BusinessManagement.Interfaces;
using RepositoryManagement.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Services
{
    public class EquityService : IEquityService
    {
        private IEquityManager _equityManager;
        private IFundManager _fundManager;

        public EquityService(IEquityManager equityManager, IFundManager fundManager)
        {
            _equityManager = equityManager;
            _fundManager = fundManager;
        }
        public async Task<bool> AddFunds(int personId, double fundAmount)
        {
            if(fundAmount> 100000)
            {
                fundAmount = fundAmount - (0.05 * fundAmount) / 100;
            }
            var result = await _fundManager.addFunds(fundAmount, personId);
            return result;
        }

        public async Task<int> BuyEquity(TraderData data)
        {
            int traderEquityId = 0;
            if (TimeService.IsTimeValidForEquityTrade())
            {
                if (TimeService.IsDayValidForEquityTrade())
                {
                    var funds = _fundManager.GetFunds(data.TraderId);
                    if (funds >= data.Amount)
                    {
                        var equityData =_equityManager.GetEquity(data.TraderId, data.CompanyName);
                        if (equityData != null)
                        {
                            await _equityManager.UpdateTraderEquity(new TraderEquity()
                            {
                                TraderEquityId = equityData.TraderEquityId,
                                TraderId = equityData.TraderId,
                                CompanyName = equityData.CompanyName,
                                Amount = data.Amount
                            });
                            await _fundManager.removeFunds(data.Amount, data.TraderId);
                            traderEquityId = equityData.TraderEquityId;
                        }
                        else
                        {
                            traderEquityId = await _equityManager.AddTraderEquity(data);
                            await _fundManager.removeFunds(data.Amount, data.TraderId);
                        }
                    }
                    else
                    {
                        traderEquityId = 0;
                    }
                }
                else
                {
                    traderEquityId = 0;
                }
            }
            else
            {
                traderEquityId = 0;
            }
            return traderEquityId;
        }

        public async Task<bool> SellEquity(TraderData data)
        {
            bool equitySold = false;
            if (data.Amount > 100)
            {
                if (TimeService.IsTimeValidForEquityTrade())
                {
                    if (TimeService.IsDayValidForEquityTrade())
                    {
                        var traderEquity = _equityManager.GetEquity(data.TraderId, data.CompanyName);
                        if (traderEquity != null)
                        {
                            if (traderEquity.Amount == data.Amount)
                            {
                                await _equityManager.RemoveEquity(traderEquity);
                                var amount = data.Amount - (0.05 * data.Amount) / 100;
                                if (amount < 20)
                                {
                                    amount = 20;
                                }
                                await _fundManager.addFunds(amount, data.TraderId);
                                equitySold = true;
                            }
                            else
                            {
                                equitySold = false;
                            }
                        }
                        else
                        {
                            equitySold = false;
                        }
                    }
                    else
                    {
                        equitySold = false;
                    }
                }
                else
                {
                    equitySold = false;
                }
            }
            else
            {
                equitySold = false;
            }
            return equitySold;
        }
    }
}
