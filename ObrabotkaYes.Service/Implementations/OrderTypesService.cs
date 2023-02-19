using Microsoft.Extensions.Logging;
using ObrabotkaYes.DataAcessLayer.Interfaces;
using ObrabotkaYes.DataAcessLayer.Repositories;
using ObrabotkaYes.Domain.Entity;
using ObrabotkaYes.Domain.Enum;
using ObrabotkaYes.Domain.Response;
using ObrabotkaYes.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Service.Implementations
{
    public class OrderTypesService : IOrderTypesService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IBaseRepository<OrderType> _orderTypeRepository;

        public OrderTypesService(ILogger<OrderService> logger, IBaseRepository<OrderType> orderTypeRepository)
        {
            _logger = logger;
            _orderTypeRepository = orderTypeRepository;
        }

        public IBaseResponce<List<OrderType>> GetAll()
        {
            try
            {
                var orderTypes = _orderTypeRepository.GetAll().ToList();
                
                if (!orderTypes.Any())
                {
                    return new BaseResponse<List<OrderType>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<OrderType>>()
                {
                    Result = orderTypes,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<OrderType>>()
                {
                    Description = $"[GetOrderTypes] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
