using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem_App.Models
{
    public class SellerModel
    {
        [Key]
        public int Seller_id { get; set; }

        public int? Seller_boss_id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Seller_fname { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Seller_lname { get; set; }
    }
}