using Microsoft.EntityFrameworkCore;
using OrderProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccess
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
