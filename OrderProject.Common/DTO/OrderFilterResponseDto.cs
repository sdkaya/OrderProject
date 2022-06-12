
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Common.DTO
{
    public class OrderFilterResponseDto
    {
        public int Count { get; set; }
        public List<OrderResponseDto> orders { get; set; }
    }
}
