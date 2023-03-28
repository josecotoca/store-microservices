namespace Store.Api.Products.Api.Dtos
{
    public class DeliverTransactionDto
    {
        public List<TransactionDetailDto> detail { get; set; }
        public DeliverTransactionDto()
        {
            detail = new List<TransactionDetailDto>();
        }
    }
}
