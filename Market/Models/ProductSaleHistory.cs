using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Models
{
    public class ProductSaleHistory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        [ForeignKey("SaleHistory")]
        public int SaleHistoryId { get; set; }
        public SaleHistory SaleHistory { get; set; }
        public List<ProductSaleHistory> ProductSaleHistories { get; set; }
        
        public decimal Income { get; set; }
    }
}
