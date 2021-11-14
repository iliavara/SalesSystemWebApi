using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem_App.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ClientModel> ClientModels { get; set; }
        public DbSet<OrderModel> OrderModels { get; set; }
        public DbSet<SellerModel> SellerModels { get; set; }
    }
}