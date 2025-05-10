namespace RestaurantApplication.Models {
    public enum MenuCategory {
        Burger,
        Pizza,
        Meal,
        Drink,
        Dessert
    }

    public class MenuItem {
        public int Id { get; set; }
        public MenuCategory Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
