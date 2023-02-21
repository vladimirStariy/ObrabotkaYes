using Microsoft.Extensions.Logging;
using ObrabotkaYes.DataAcessLayer.Interfaces;
using ObrabotkaYes.DataAcessLayer.Repositories;
using ObrabotkaYes.Domain.Entity;
using ObrabotkaYes.Domain.Enum;
using ObrabotkaYes.Domain.Response;
using ObrabotkaYes.Domain.ViewModels;
using ObrabotkaYes.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IBaseRepository<Category> _categoryRepository;

        public CategoryService(ILogger<OrderService> logger, IBaseRepository<Category> categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public async Task<IBaseResponce<Category>> Create(CategoryViewModel model)
        {
            try
            {
                var category = new Category()
                {
                    Name = model.Name,
                    Description = model.Description
                };

                await _categoryRepository.Create(category);

                return new BaseResponse<Category>()
                {
                    Result = category,
                    Description = "Объект добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[CategoryService.Create] error: {ex.Message}");
                return new BaseResponse<Category>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public IBaseResponce<List<Category>> GetCategories()
        {
            try
            {
                var categories = _categoryRepository.GetAll().ToList();
                if (!categories.Any())
                {
                    return new BaseResponse<List<Category>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Category>>()
                {
                    Result = categories,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Category>>()
                {
                    Description = $"[GetCategories] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
