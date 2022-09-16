using ObrabotkaYes.DataAcessLayer.Interfaces;
using ObrabotkaYes.Domain.Entity;
using ObrabotkaYes.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.DataAcessLayer.Repositories
{
    public class CompanyRepository : IBaseRepository<Company>
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task Create(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Company entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Company> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Company> Update(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
