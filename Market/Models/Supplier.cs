using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Agent { get; set; }
        public List<Product> Products { get; set; }
    }
}
