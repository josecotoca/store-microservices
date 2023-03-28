using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Products.Api.Dtos;
using Store.Api.Products.Persistence.Entities;
using Store.Api.Products.Services.Commands;
using Store.Api.Products.Services.Queries;
using static Store.Api.Products.Services.Commands.CommandEditProduct;

namespace Store.Api.Products.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<Unit>> CreateProduct(ProductAddDto product)
        {
            var request = _mapper.Map<RequestProduct>(product);
            return await Mediator.Send(request);
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var request = new QueryGetProducts.ProductGetResponse();
            return await Mediator.Send(request);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var request = new QueryGetProductById.ProductById { Id = id };
            return await Mediator.Send(request);
        }

        [HttpPut]
        [Produces("application/json")]
        public async Task<ActionResult<Unit>> UpdateProduct(ProductEditDto product)
        {
            var request = _mapper.Map<CommandEditProduct.ProductEditRequest>(product);
            return await Mediator.Send(request);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Unit>> DeleteProduct(int id)
        {
            var request = new CommandDeleteProduct.DeleteById { Id = id };
            return await Mediator.Send(request);
        }

        

    }
}
