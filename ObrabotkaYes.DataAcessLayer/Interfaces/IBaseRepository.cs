﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.DataAcessLayer.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        IQueryable<T> GetAll();
    }
}
