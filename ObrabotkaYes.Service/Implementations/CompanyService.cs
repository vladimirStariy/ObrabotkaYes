using Microsoft.Extensions.Logging;
using ObrabotkaYes.Domain.Entity;
using ObrabotkaYes.Domain.Response;
using ObrabotkaYes.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Service.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ILogger<CompanyService> _logger;

        public CompanyService(ILogger<CompanyService> logger)
        {
            _logger = logger;
        }

        public Task<IBaseResponce<Company>> Create(Company model)
        {
            throw new NotImplementedException();
        }
    }
}
