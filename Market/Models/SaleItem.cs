namespace Market.Models
{
    public class SaleItem
    {
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal Total { get; set; }
        public int SaleRowId { get; set; }

        public SaleItem()
        {
            Count = 1;
        }
    }
}
