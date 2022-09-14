using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using ObrabotkaYes.DataAcessLayer.Interfaces;
using ObrabotkaYes.Domain.Entity;
using ObrabotkaYes.Domain.Enum;
using ObrabotkaYes.Domain.Response;
using ObrabotkaYes.Domain.ViewModels;
using ObrabotkaYes.Service.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ObrabotkaYes.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IBaseRepository<OrderPicture> _orderPictureRepository;
        private readonly IBaseRepository<Category> _categoryRepository;
        IHostingEnvironment _appEnvironment;

        public OrderService(
            ILogger<OrderService> logger, 
            IBaseRepository<Order> orderRepository, 
            IBaseRepository<OrderPicture> orderPictureRepository, 
            IBaseRepository<Category> categoryRepository,
            IHostingEnvironment appEnvironment)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _orderPictureRepository = orderPictureRepository;
            _categoryRepository = categoryRepository;
            _appEnvironment = appEnvironment;
        }

        public async Task<IBaseResponce<Order>> Create(OrderViewModel model)
        {
            try 
            {
                List<Category> _categories = new List<Category>();
                foreach (var category_id in model.Categories)
                {
                    var cat = _categoryRepository.GetAll().ToList().Where(x => x.Category_ID == category_id);
                    _categories.Add(cat.FirstOrDefault());
                }
                var order = new Order()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Phone = model.Phone,
                    PublicationDate = DateTime.Now,
                    Type_ID = model.Type_ID,
                    Categories = _categories
                };

                await _orderRepository.Create(order);

                if(model.Uploads.Count > 0)
                {
                    foreach (var item in model.Uploads)
                    {
                        string path = "/Images/" + item.FileName;
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await item.CopyToAsync(fileStream);
                        }
                        var orderPicture = new OrderPicture()
                        {
                            Order_ID = order.Order_ID,
                            Name = item.Name,
                            ImagePath = path
                        };
                        await _orderPictureRepository.Create(orderPicture);
                    }
                }

                return new BaseResponse<Order>()
                {
                    Result = order,
                    Description = "Объект добавился",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[OrderService.Create] error: {ex.Message}");
                return new BaseResponse<Order>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public IBaseResponce<List<Order>> GetOrders()
        {
            try 
            {
                var orders = _orderRepository.GetAll().ToList();
                if (_orderPictureRepository.GetAll().Count() != 0)
                {
                    foreach (var item in orders)
                    {
                        item.OrderPictures = _orderPictureRepository.GetAll().Where(x => x.Order_ID == item.Order_ID).ToList();
                    }
                }             
                foreach (var cat in orders)
                {
                    
                }
                if (!orders.Any())
                {
                    return new BaseResponse<List<Order>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Order>>()
                {
                    Result = orders,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Order>>()
                {
                    Description = $"[GetOrders] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponce<List<OrderViewModel>> GetOrdersView()
        {
            throw new NotImplementedException();
        }
    }
}
