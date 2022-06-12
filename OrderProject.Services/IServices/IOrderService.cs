using OrderProject.Common.DTO;
using OrderProject.Common.Helper;
using OrderProject.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Services.IServices
{
    public interface IOrderService
    {
        Task<Response<bool>> CreateJoinRequest(List<CreateOrderDto> createOrderDtoList);
        Task<Response<OrderFilterResponseDto>> FilterBy(OrderFilterModel orderFilterModel);
    }
}
