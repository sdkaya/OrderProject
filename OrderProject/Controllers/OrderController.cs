using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.Common.DTO;
using OrderProject.Common.Helper;
using OrderProject.Common.ViewModels;
using OrderProject.Services.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }



        [HttpPost("CreateOrder")]
        public async Task<Response<bool>> CreateComment(List<CreateOrderDto> dto)
        {
            try
            {
                var result = await _orderService.CreateOrder(dto);
                return new Response<bool>() { isSuccess = result.Data, Data = result.Data, List = null, Message = result.Message, Status = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {

                return new Response<bool>() { isSuccess = false, Data = false, List = null, Message = ex.Message, Status = StatusCodes.Status500InternalServerError };
            }



        }


        [HttpPost("FilterOrder")]
        public async Task<Response<OrderFilterResponseDto>> FilterOrder(OrderFilterModel filterModel)
        {
            try
            {
                var result = await _orderService.FilterBy(filterModel);
                return new Response<OrderFilterResponseDto>() { isSuccess = true, Data = result.Data, List = null, Message = result.Message, Status = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {

                return new Response<OrderFilterResponseDto>() { isSuccess = false, Data = null, List = null, Message = ex.Message, Status = StatusCodes.Status500InternalServerError };
            }



        }


    }
}
