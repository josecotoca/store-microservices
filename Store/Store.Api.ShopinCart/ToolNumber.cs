namespace Store.Api.ShopinCart
{
    public static class ToolNumber
    {
        public static double calculatePercent(double amount, double percent)
        {
            var value = Math.Round(Convert.ToDecimal(amount * percent), 2);
            return (double)value;
        }
    }
}
