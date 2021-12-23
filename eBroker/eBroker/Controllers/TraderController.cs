using BusinessManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RepositoryManagement;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBroker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TraderController : ControllerBase
    {
        private IEquityService _equityService;

        public TraderController(IEquityService equityService)
        {
            _equityService = equityService;
        }

        public TraderController()
        {
        }

        [HttpPost("buy/equity")]
        public async Task<IActionResult> BuyEquity(TraderData data)
        {
            var result = await _equityService.BuyEquity(data);
            if (result != 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("sell/equity")]
        public async Task<IActionResult> SellEquity(TraderData data)
        {
            var result = await _equityService.SellEquity(data);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("addfund")]
        public async Task<IActionResult> AddFunds(TraderFund data)
        {
            var result = await _equityService.AddFunds(data.TraderId, data.Amount);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
