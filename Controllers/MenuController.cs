using food_menu.Data;
using food_menu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace food_menu.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuContext _context;


        public MenuController(MenuContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Dishes.ToListAsync());
        }
    }
}