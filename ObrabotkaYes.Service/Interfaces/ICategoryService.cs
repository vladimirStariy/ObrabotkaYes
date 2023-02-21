using ObrabotkaYes.Domain.Entity;
using ObrabotkaYes.Domain.Response;
using ObrabotkaYes.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IBaseResponce<Category>> Create(CategoryViewModel model);
        IBaseResponce<List<Category>> GetCategories();
    }
}
