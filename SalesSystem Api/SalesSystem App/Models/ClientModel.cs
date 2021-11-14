using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem_App.Models
{
    public class ClientModel
    {
        [Key]
        public int Client_id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Client_fname { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Client_lname { get; set; }
    }
}