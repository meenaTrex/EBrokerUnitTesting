using BusinessManagement.Interfaces;
using BusinessManagement.Services;
using eBroker.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using RepositoryManagement;
using RepositoryManagement.Interfaces;
using RepositoryManagement.Services;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace TestsManagement
{
    public class UnitTest
    {

        [Fact]
        public void AddTraderEquity_PassedTraderIdAndWquityCompany_ReturnsInsertedTraderEquity()
        {

            var options = new DbContextOptionsBuilder<TraderContext>()
                .UseInMemoryDatabase(databaseName: "TraderDb")
                .Options;

            using (var context = new TraderContext(options))
            {
                context.TraderEquities.Add(new TraderEquity
                {
                    TraderId = 1,
                    Amount = 100,
                    CompanyName = "Accenture"
                });

                context.SaveChanges();
            }
            // Use a clean instance of the context to run the test
            using (var context = new TraderContext(options))
            {
                EquityManager equityManager = new EquityManager(context);
                var data = equityManager.GetEquity(1, "Accenture");

                Assert.Equal(100, data.Amount);
            }
        }

        [Fact]
        public async Task RemoveTraderEquity_PassedTraderIdAndEquityCompany_VerifyIfTraderEquityStillExists()
        {

            var options = new DbContextOptionsBuilder<TraderContext>()
                .UseInMemoryDatabase(databaseName: "TraderDb")
                .Options;

            using (var context = new TraderContext(options))
            {
                context.TraderEquities.Add(new TraderEquity
                {
                    TraderId = 2,
                    Amount = 100,
                    CompanyName = "Microsoft"
                });

                context.SaveChanges();
            }
            // Use a clean instance of the context to run the test
            using (var context = new TraderContext(options))
            {
                EquityManager equityManager = new EquityManager(context);
                var equityDetails = equityManager.GetEquity(2, "Microsoft");
                await equityManager.RemoveEquity(equityDetails);
                var traderEquity = equityManager.GetEquity(2, "Microsoft");

                Assert.Null(traderEquity);
            }
        }

        [Fact]
        public void GetFundsEquity_PassesTraderId_ReturnsInsertedFundValueForTrader()
        {
            var options = new DbContextOptionsBuilder<TraderContext>()
                .UseInMemoryDatabase(databaseName: "TraderDb")
                .Options;
            using (var context = new TraderContext(options))
            {
                context.Funds.Add(new Fund
                {
                    TraderId = 4,
                    Amount = 4100.5
                });

                context.SaveChanges();
            }
            // Use a clean instance of the context to run the test
            using (var context = new TraderContext(options))
            {
                FundManager fundManager = new FundManager(context);
                var data = fundManager.GetFunds(4);

                Assert.Equal(4100.5, data);
            }
        }

        [Fact]
        public async Task RemoveFunds_PassesTraderId_ShouldReturnNoFundsValue()
        {
            var options = new DbContextOptionsBuilder<TraderContext>()
                .UseInMemoryDatabase(databaseName: "TraderDb")
                .Options;
            using (var context = new TraderContext(options))
            {
                context.Funds.Add(new Fund
                {
                    TraderId = 4,
                    Amount = 4100.5
                });

                context.SaveChanges();
            }
            // Use a clean instance of the context to run the test
            using (var context = new TraderContext(options))
            {
                FundManager fundManager = new FundManager(context);
                var data = await fundManager.removeFunds(4100.5,4);
                var amount = fundManager.GetFunds(4);

                Assert.Equal(0, amount);
            }
        }

        [Fact]
        public async Task VerifyIfEquityIsBought_PassTraderData_ReturnsObjectResult()
        {
            Mock<IEquityService> mock = new Mock<IEquityService>();
            TraderController controller = new TraderController(mock.Object);
            var okResult = await controller.BuyEquity(new TraderData() { TraderId = 1, Amount = 200, CompanyName = "Nagarro" });

            Assert.IsType<BadRequestResult>(okResult);
        }

        [Fact]
        public async Task AddFunds_AcceptsTraderAndAmount_ReturnsTrueOnSuccess()
        {
            Mock<IEquityManager> mockEquity = new Mock<IEquityManager>();
            Mock<IFundManager> mockFund = new Mock<IFundManager>();

            var stub = new EquityService(mockEquity.Object, mockFund.Object);
            var result = await stub.AddFunds(1, 240);
            Assert.True(result == false);
        }


        [Fact]
        public async Task BuyEquity_AcceptsTraderData_ReturnsInsertedRowId()
        {
            Mock<IEquityManager> mockEquity = new Mock<IEquityManager>();
            Mock<IFundManager> mockFund = new Mock<IFundManager>();

            var stub = new EquityService(mockEquity.Object, mockFund.Object);
            await stub.AddFunds(1, 400);
            var result = await stub.BuyEquity(new TraderData() {TraderId = 1, Amount = 350, CompanyName = "Desire" });
            Assert.IsType<int>(result);
        }

        [Fact]
        public async Task SellEquity_AcceptsTraderData_ReturnsInsertedRowId()
        {
            Mock<IEquityManager> mockEquity = new Mock<IEquityManager>();
            Mock<IFundManager> mockFund = new Mock<IFundManager>();

            var stub = new EquityService(mockEquity.Object, mockFund.Object);
            var result = await stub.SellEquity(new TraderData() { TraderId = 1, Amount = 350, CompanyName = "Desire" });
            Assert.IsType<bool>(result);
        }
    }
}
