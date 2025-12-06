namespace food_menu.Models
{
    public class DishIngredient
    {
        public int Id { get; set; }

        public Dish dish { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }


        
    }
}
