using ObrabotkaYes.Domain.Entity;
using ObrabotkaYes.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Service.Interfaces
{
    public interface IOperationService
    {
        IBaseResponce<List<Operation>> GetOperations();
    }
}
