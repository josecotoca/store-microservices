using System.ComponentModel;

namespace Store.Api.ShopinCart.Api.Dtos
{
    public class SaleDto
    {
        [DefaultValue("DEVELOPER SRL")]
        public string InvoiceName { get; set; }

        [DefaultValue("195372027")]
        public string InvoiceNit { get; set; }

        [DefaultValue("VENTA DE PRUEBAS")]
        public string? Observation { get; set; }
        public DateTime Date { get; set; }
        [DefaultValue(100)]
        public double SubTotal { get; set; }

        public List<SaleDetailDto> Detail { get; set; }
        
        public SaleDto() {
            Detail = new List<SaleDetailDto>();
        }
    }
}
