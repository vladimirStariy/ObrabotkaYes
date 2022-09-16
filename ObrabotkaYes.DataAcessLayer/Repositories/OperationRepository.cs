
using ObrabotkaYes.DataAcessLayer.Interfaces;
using ObrabotkaYes.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.DataAcessLayer.Repositories
{
    public class OperationRepository : IBaseRepository<Operation>
    {
        private readonly ApplicationDbContext _db;

        public OperationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task Create(Operation entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Operation entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Operation> GetAll()
        {
            return _db.Operations;
        }

        public Task<Operation> Update(Operation entity)
        {
            throw new NotImplementedException();
        }
    }
}
