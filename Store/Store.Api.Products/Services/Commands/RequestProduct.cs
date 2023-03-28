using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Api.Products.Services.Commands
{
    public class RequestProduct : IRequest
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool ForInventory { get; set; }
        public bool ForSale { get; set; }
        public Double Price { get; set; }
    }
}