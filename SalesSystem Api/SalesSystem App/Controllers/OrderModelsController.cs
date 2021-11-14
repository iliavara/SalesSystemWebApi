using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesSystem_App.Implementations;
using SalesSystem_App.Interfaces;
using SalesSystem_App.Models;
using SalesSystem_App.Responses;

namespace SalesSystem_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderModelsController : ControllerBase
    {
        private readonly IOrdersRepository _repository;

        public OrderModelsController(IOrdersRepository repository)
        {
            _repository = repository;
        }

        // GET: api/OrderModels
        [HttpGet]
        public ActionResult<IEnumerable<OrderResponse>> GetOrders()
        {
            var orders = _repository.Order_list();
            
            if(orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // GET: api/OrderModels/5
        [HttpGet("{from}/{to}")]
        public ActionResult<string> GetLastOrder(DateTime from, DateTime to)
        {
           var lastOrder =  _repository.GetOrderWithDateRange(from, to);

            if(lastOrder == null)
            {
                return NotFound();
            }

            return lastOrder;
        }
    }
}
