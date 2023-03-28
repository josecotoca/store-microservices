using MediatR;

namespace Store.Api.Products.Services.Commands
{
    public class RequestProductTransaction : IRequest
    {
        public bool IsRevenue { get; set; } = true;
        public List<RequestProductTransactionDetail> detail = new List<RequestProductTransactionDetail>();
    }
}
