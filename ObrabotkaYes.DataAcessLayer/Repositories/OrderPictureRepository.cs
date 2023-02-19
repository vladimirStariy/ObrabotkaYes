using ObrabotkaYes.DataAcessLayer.Interfaces;
using ObrabotkaYes.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.DataAcessLayer.Repositories
{
    public class OrderPictureRepository : IBaseRepository<OrderPicture>
    {
        private readonly ApplicationDbContext _db;

        public OrderPictureRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(OrderPicture entity)
        {
            await _db.OrderPictures.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(OrderPicture entity)
        {
            _db.OrderPictures.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<OrderPicture> GetAll()
        {
            return _db.OrderPictures;
        }

        public async Task<OrderPicture> Update(OrderPicture entity)
        {
            _db.OrderPictures.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
