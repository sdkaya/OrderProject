using OrderProject.Common.ViewModels;
using OrderProject.DataAccess.IRepository;
using OrderProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccess.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext context)
            : base(context)
        {
        }

    }
}
