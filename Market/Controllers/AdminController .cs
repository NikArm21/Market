using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.Controllers
{
    public class AdminController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        public AdminController(RoleManager<IdentityRole> manager)
        {
            _roleManager = manager;
        }

        public async Task<IActionResult> GetRoles()
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            return View(await _roleManager.Roles.ToListAsync());
        }
    }
}
