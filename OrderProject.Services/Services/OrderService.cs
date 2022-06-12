using Microsoft.AspNetCore.Http;
using OrderProject.Common.DTO;
using OrderProject.Common.Helper;
using OrderProject.Common.ViewModels;
using OrderProject.DataAccess.IRepository;
using OrderProject.Entity.Entities;
using OrderProject.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Response<bool>> CreateOrder(List<CreateOrderDto> createOrderDtoList)
        {
            try
            {
                foreach (var item in createOrderDtoList)
                {
                    if (item.BrandId > 0)
                    {
                        var order = new Order()
                        {
                            BrandId = item.BrandId,
                            CreatedOn = DateTime.Now,
                            CustomerName = item.CustomerName,
                            Price = item.Price,
                            Status = item.Status,
                            StoreName = item.StoreName,
                        };

                        await _orderRepository.CreateAsync(order);
                    }
                }

                return new Response<bool>() { isSuccess = true, Data = true, List = null, Message = "Success", Status = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return new Response<bool>() { isSuccess = false, Data = false, List = null, Message = ex.Message, Status = StatusCodes.Status500InternalServerError };
            }
        }

        public async Task<Response<OrderFilterResponseDto>> FilterBy(OrderFilterModel orderFilterModel)
        {
            try
            {
                var query = _orderRepository.GetAllAsync();

                if (orderFilterModel.StartDate != null)
                {
                    query = query.Where(x => x.CreatedOn >= orderFilterModel.StartDate);
                }

                if (!String.IsNullOrEmpty(orderFilterModel.SearchText))
                {
                    query = query.Where(x => x.StoreName.Contains(orderFilterModel.SearchText) || x.CustomerName.Contains(orderFilterModel.SearchText));
                }
                if(orderFilterModel.EndDate != null)
                {
                    query = query.Where(x => x.CreatedOn <= orderFilterModel.StartDate);
                }

                var result = new OrderFilterResponseDto()
                {
                    Count = query.Count(),
                    orders = query.Select(x=> new OrderResponseDto()
                    {
                        BrandId = x.BrandId,
                        CreatedOn = x.CreatedOn,
                        CustomerName = x.CustomerName,
                        Price = x.Price,
                        Status = x.Status,
                        StoreName = x.StoreName,

                    }).ToList(),
                  
                };

                return new Response<OrderFilterResponseDto>() { isSuccess = true, Data = result, List = null, Message = "Success", Status = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {

                return new Response<OrderFilterResponseDto>() { isSuccess = false, Data = null, List = null, Message = ex.Message, Status = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
