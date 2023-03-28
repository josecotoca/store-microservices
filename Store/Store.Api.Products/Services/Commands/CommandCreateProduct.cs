using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Api.Products.Persistence.Entities;
using Store.Api.Products.Persistence;
using System.ComponentModel.DataAnnotations.Schema;
using Store.Api.Products.Persistence.Repositories;
using AutoMapper;

namespace Store.Api.Products.Services.Commands
{
    public class CommandCreateProduct
    {
        public class Manager : IRequestHandler<RequestProduct>
        {
            private readonly ICommandProductRepository productRepository;
            private readonly IMapper mapper;

            public Manager(ICommandProductRepository _productRepository, IMapper _mapper)
            {
                productRepository = _productRepository;
                mapper = _mapper;
            }

            public async Task<Unit> Handle(RequestProduct request, CancellationToken cancellationToken)
            {
                var product = mapper.Map<Product>(request);
                var result = await productRepository.AddAsync(product);
                if (result > 0)
                    return Unit.Value;

                throw new Exception("Error Creating Product.");
            }
        }
    }
}
