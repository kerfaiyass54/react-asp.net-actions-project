using Microsoft.AspNetCore.Mvc;
using food_menu.Data;
using food_menu.Models;

namespace food_menu.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
