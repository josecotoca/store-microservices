namespace Store.Api.Products.Api.Dtos
{
    public class TransactionDto
    {
        public bool IsRevenue { get; set; } = true;
        public List<TransactionDetailDto> detail { get; set; }
        public TransactionDto() {
            detail = new List<TransactionDetailDto>();
        }
    }

    public class TransactionDetailDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
