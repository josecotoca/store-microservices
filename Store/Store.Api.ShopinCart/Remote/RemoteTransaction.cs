namespace Store.Api.ShopinCart.Remote
{
    public class RemoteTransaction
    {
        public bool IsRevenue { get; set; } = true;
        public List<RemoteTransactionDetail> detail { get; set; }
        public RemoteTransaction()
        {
            detail = new List<RemoteTransactionDetail>();
        }
    }
}