using Microsoft.AspNetCore.Http;
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
    public interface IOrderService
    {
        Task<IBaseResponce<Order>> Create(OrderViewModel model);
        IBaseResponce<List<Order>> GetOrders();
        IBaseResponce<List<OrderViewModel>> GetOrdersView();
    }
}
