using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem_App.Models
{
    public class OrderModel
    {
        [Key]
        public int Order_id { get; set; }

        public int? Order_parent_id { get; set; }

        [ForeignKey("Clients_Orders_FK1")]
        public ClientModel Order_client_id { get; set; }

        [ForeignKey("Sellers_Orders_FK2")]
        public SellerModel Order_seller_id { get; set; }

        [Required]
        public uint Order_amount;

        [Required]
        public DateTime Order_date { get; set; }

    }
}