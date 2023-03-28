using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Api.Products.Api.Dtos
{
    public class ProductAddDto
    {
        [DefaultValue("PRO-0001")]
        public string Code { get; set; }

        [DefaultValue("POLERA HERING BLANCA")]
        public string Name { get; set; }

        [DefaultValue("POLERA DE ALGODON UNISEX COLOR BLANCA SENCILLA")]
        public string Description { get; set; }

        [DefaultValue(true)]
        public bool ForInventory { get; set; }

        [DefaultValue(true)]
        public bool ForSale { get; set; }

        [DefaultValue(0d)]
        public Double Price { get; set; }
    }
}