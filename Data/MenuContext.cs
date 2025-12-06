using Microsoft.EntityFrameworkCore;
using food_menu.Models;

namespace food_menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);
            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id=1 , Name="Margheritta", Price=7.50}
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id=1, Name="Sauce" },
                new Ingredient { Id=2, Name="Mozarella" }
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 2, IngredientId = 2 }
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
