using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class SaleHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Result { get; set; }
    }
}
