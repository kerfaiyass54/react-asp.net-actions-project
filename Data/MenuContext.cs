using Microsoft.EntityFrameworkCore;
using food_menu.Models;

namespace food_menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map tables
            modelBuilder.Entity<Dish>().ToTable("dish");
            modelBuilder.Entity<Dish>().Property(d => d.Id).HasColumnName("id");
            modelBuilder.Entity<Dish>().Property(d => d.Name).HasColumnName("name");
            modelBuilder.Entity<Dish>().Property(d => d.Price).HasColumnName("price");

            modelBuilder.Entity<Ingredient>().ToTable("ingredient");
            modelBuilder.Entity<Ingredient>().Property(i => i.Id).HasColumnName("id");
            modelBuilder.Entity<Ingredient>().Property(i => i.Name).HasColumnName("name");

            modelBuilder.Entity<DishIngredient>().ToTable("dish_ingredient");
            modelBuilder.Entity<DishIngredient>().HasKey(di => new { di.DishId, di.IngredientId });
            modelBuilder.Entity<DishIngredient>().Property(di => di.DishId).HasColumnName("dish_id");
            modelBuilder.Entity<DishIngredient>().Property(di => di.IngredientId).HasColumnName("ingredient_id");

            // Relationships
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredientId);
        }
    }
}
