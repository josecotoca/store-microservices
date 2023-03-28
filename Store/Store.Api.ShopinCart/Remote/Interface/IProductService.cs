namespace Store.Api.ShopinCart.Remote.Interface
{
    public interface IProductService
    {
        Task<(bool resul, Product product, string Msg)> GetProduct(int id);
        Task<(bool resul, string Msg)> SetTransactionPost(Object data, string resourceUri, string api);
    }
}
