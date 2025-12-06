using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using food_menu.Data;
using food_menu.Models;
using System.Linq;
using System.Threading.Tasks;

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
            var count = await _context.Dishes.CountAsync();
            Console.WriteLine($"Number of dishes: {count}");

            var dishes = await _context.Dishes
                .Include(d => d.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                .ToListAsync();

            return View(dishes);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null) return NotFound();

            var dish = await _context.Dishes
                .Include(d => d.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dish == null) return NotFound();

            return View(dish);
        }
    }
}
