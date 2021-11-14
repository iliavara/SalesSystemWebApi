using SalesSystem_App.Models;
using SalesSystem_App.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem_App.Interfaces
{
    public interface IOrdersRepository
    {
        public List<OrderResponse> Order_list();

        public string GetOrderWithDateRange(DateTime from, DateTime to);
    }
}
