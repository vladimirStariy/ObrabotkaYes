using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
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

namespace ObrabotkaYes.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IBaseRepository<OrderPicture> _orderPictureRepository;

        public OrderService(ILogger<OrderService> logger, IBaseRepository<Order> orderRepository, IBaseRepository<OrderPicture> orderPictureRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _orderPictureRepository = orderPictureRepository;
        }

        public async Task<IBaseResponce<Order>> Create(OrderViewModel model, IFormFileCollection uploads)
        {
            try 
            {
                var order = new Order()
                {
                    Name = model.Name
                };

                await _orderRepository.Create(order);

                if(uploads.Count != 0)
                {
                    foreach (var item in uploads)
                    {
                        string path = "/Images/" + item.FileName;
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
                if(!orders.Any())
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
    }
}
