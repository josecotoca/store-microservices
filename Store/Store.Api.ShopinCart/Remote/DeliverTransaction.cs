namespace Store.Api.ShopinCart.Remote
{
    public class DeliverTransaction
    {
        public List<RemoteTransactionDetail> detail { get; set; }
        public DeliverTransaction()
        {
            detail = new List<RemoteTransactionDetail>();
        }
    }
}
