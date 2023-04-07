using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
