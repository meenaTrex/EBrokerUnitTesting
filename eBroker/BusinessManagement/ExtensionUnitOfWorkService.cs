using Microsoft.Extensions.DependencyInjection;
using RepositoryManagement.Interfaces;
using RepositoryManagement.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement
{
    public static class ExtensionUnitOfWorkService
    {
        /// <summary>
        /// Registers the repositories.
        /// </summary>
        /// <param name="service">The service collection.</param>
		public static void RegisterRepositories(this IServiceCollection service)
        {
            service.AddTransient<IEquityManager, EquityManager>();
            service.AddTransient<IFundManager, FundManager>();
            // service.AddScoped<IAccountUnitOfWork, AccountUnitOfWork>();
        }
    }
}
