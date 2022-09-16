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
    public class OperationService : IOperationService
    {
        private readonly ILogger<OperationService> _logger;

        public OperationService(ILogger<OperationService> logger)
        {
            _logger = logger;
        }

        public IBaseResponce<List<Operation>> GetOperations()
        {
            throw new NotImplementedException();
        }
    }
}
