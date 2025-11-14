using food_menu.Models;
using Microsoft.EntityFrameworkCore;

namespace food_menu.Data
{
    public class MenuContext : DbContext
    {

        public MenuContext( DbContextOptions<MenuContext> options ) : base( options ) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            }
                );

            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
