using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Api.ShopinCart.Api.Dtos;
using Store.Api.ShopinCart.Services.Commands;
using Store.Api.ShopinCart.Services.Queries;

namespace Store.Api.ShopinCart.Api.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class ShopinCartController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public ShopinCartController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<Unit>> CreateSale(SaleDto sale)
        {
            var request = _mapper.Map<RequestCreateSale>(sale);
            return await Mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDto>> GetSale(int id)
        {
            return await Mediator.Send(new QueryGetSale.SaleGetResponse { Id = id });
        }

        [HttpGet("deliver/{id}")]
        public async Task<ActionResult<Unit>> SaleDelivery(int id)
        {
            return await Mediator.Send(new CommandDeliverSale.RequestDeliverSale { Id = id });
        }

        

    }
}
