using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem_App.Responses
{
    public class OrderResponse
    {
        public int Order_id { get; set; }
        public int Order_Count { get; set; }
        public DateTime Order_date { get; set; }
        public uint Total_amount { get; set; }
    }
}
