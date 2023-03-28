using MediatR;

namespace Store.Api.Products.Services.Commands
{
    public class RequestDeliveredProduct : IRequest
    {
        public List<RequestProductTransactionDetail> detail = new List<RequestProductTransactionDetail>();
    }
}
