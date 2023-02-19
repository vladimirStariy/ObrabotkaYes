using ObrabotkaYes.DataAcessLayer.Interfaces;
using ObrabotkaYes.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.DataAcessLayer.Repositories
{
    public class OrderTypeRepository : IBaseRepository<OrderType>
    {
        private readonly ApplicationDbContext _db;

        public OrderTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(OrderType entity)
        {
            await _db.OrderTypes.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public Task Delete(OrderType entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<OrderType> GetAll()
        {
            return _db.OrderTypes;
        }

        public Task<OrderType> Update(OrderType entity)
        {
            throw new NotImplementedException();
        }
    }
}
