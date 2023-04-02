using Microsoft.AspNetCore.Identity;

namespace Market.Models
{
    public class Employee:IdentityUser

    {
        public string FullName { get; set; }
    }
}
