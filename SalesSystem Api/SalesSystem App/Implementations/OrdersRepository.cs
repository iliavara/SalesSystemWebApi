using SalesSystem_App.Interfaces;
using SalesSystem_App.Models;
using SalesSystem_App.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem_App.Implementations
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly DataContext _context;

        public OrdersRepository(DataContext context)
        {
            _context = context;
        }

        public string GetOrderWithDateRange(DateTime from, DateTime to)
        {
            var match = _context.OrderModels.Where(x => x.Order_parent_id == null && x.Order_date >= from && x.Order_date <= to).OrderByDescending(y=>y.Order_date).FirstOrDefault();
            return match.Order_id.ToString() + ", " + match.Order_amount.ToString();
        }

        public List<OrderResponse> Order_list()
        {
            var parent_lst = _context.OrderModels.Where(x => x.Order_parent_id == null).ToList();
            List<OrderResponse> orderResponse_list = new List<OrderResponse>();
            foreach (var p in parent_lst)
            {
                var child = _context.OrderModels.Where(y => y.Order_parent_id == p.Order_id).FirstOrDefault();

                int order_id = p.Order_id;

                int order_count = 1;
                if (child != null) { order_count += 1; }

                DateTime Order_time = p.Order_date;
                if (child != null || p.Order_date <= child.Order_date) { Order_time = child.Order_date; }

                uint total_amount = p.Order_amount;
                if (child != null) { total_amount = child.Order_amount; }
                OrderResponse order_response = new OrderResponse();
                order_response.Order_id = order_id;
                order_response.Order_Count = order_count;
                order_response.Order_date = Order_time;
                order_response.Total_amount = total_amount;
                orderResponse_list.Add(order_response);
            }
            return orderResponse_list;
        }
    }
}
