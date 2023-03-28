using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Store.Api.Products.Api.Dtos
{
    public class ProductDto: ProductAddDto
    {
        public int Id { get; set; }
        public double Stock { get; set; }
        public double StockPendingDelivery { get; set; }
    }
}