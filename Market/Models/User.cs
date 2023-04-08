using Microsoft.AspNetCore.Identity;

namespace Market.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public int Year { get; set; }
    }
}
