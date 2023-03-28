using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Products.Api.Dtos;
using Store.Api.Products.Services.Commands;

namespace Store.Api.Products.Api.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public TransactionController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<Unit>> CreateTransaction(TransactionDto transaction)
        {
            var request = _mapper.Map<RequestProductTransaction>(transaction);
            return await Mediator.Send(request);
        }

        [HttpPost("deliver")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<Unit>> DeliverTransaction(DeliverTransactionDto transaction)
        {
            var request = _mapper.Map<RequestDeliveredProduct>(transaction);
            return await Mediator.Send(request);
        }

    }
}
