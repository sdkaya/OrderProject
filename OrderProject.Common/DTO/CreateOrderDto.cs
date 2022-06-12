using OrderProject.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Common.DTO
{
    public class CreateOrderDto
    {
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public string StoreName { get; set; }
        public string CustomerName { get; set; }
        public OrderStatus Status { get; set; }
    }
}
