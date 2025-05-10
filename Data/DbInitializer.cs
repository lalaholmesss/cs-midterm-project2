using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantApplication.Models;

namespace RestaurantApplication.Data {
    public static class DbInitializer {
        public static void Initialize(ApplicationDbContext context) {
            if (!context.Staffs.Any()) {
                context.Staffs.Add(new Staff {
                    Username = "admin",
                    Password = "admin123"
                });
                context.SaveChanges();
            }

            if (!context.MenuItems.Any()) {
                var items = new MenuItem[]
                {
                    new MenuItem { Name = "Classic Cheeseburger", Description = "Beef patty, cheddar cheese, lettuce, tomato, and our signature sauce.", Price = 8.99M, ImageUrl = "classic-cheeseburger.jpg", Category = MenuCategory.Burger },
                    new MenuItem { Name = "BBQ Bacon Burger", Description = "Smoky BBQ sauce, crispy bacon, and grilled onions.", Price = 9.49M, ImageUrl = "bbq-bacon-cheeseburger.jpg", Category = MenuCategory.Burger },
                    new MenuItem { Name = "Veggie Burger", Description = "Grilled plant-based patty with avocado and sprouts.", Price = 7.99M, ImageUrl = "veggie_burger.jpg", Category = MenuCategory.Burger },
                    new MenuItem { Name = "Spicy Jalapeño Burger", Description = "Pepper jack cheese, jalapeños, chipotle mayo.", Price = 8.75M, ImageUrl = "spicy_burger.jpg", Category = MenuCategory.Burger },

                    new MenuItem { Name = "Margherita Pizza", Description = "Tomato sauce, mozzarella, fresh basil.", Price = 10.00M, ImageUrl = "margherita.jpeg", Category = MenuCategory.Pizza },
                    new MenuItem { Name = "Pepperoni Pizza", Description = "Classic pepperoni with cheese and marinara.", Price = 11.50M, ImageUrl = "pepperoni.jpg", Category = MenuCategory.Pizza },
                    new MenuItem { Name = "Veggie Supreme", Description = "Bell peppers, olives, mushrooms, and onions.", Price = 10.75M, ImageUrl = "veggie_pizza.jpg", Category = MenuCategory.Pizza },
                    new MenuItem { Name = "Four Cheese Pizza", Description = "Mozzarella, cheddar, parmesan, and gorgonzola.", Price = 12.00M, ImageUrl = "four_cheese.jpg", Category = MenuCategory.Pizza },

                    new MenuItem { Name = "Grilled Chicken Plate", Description = "Grilled chicken with rice and seasonal vegetables.", Price = 13.99M, ImageUrl = "grilled_chicken.jpg", Category = MenuCategory.Meal },
                    new MenuItem { Name = "Beef Shawarma Bowl", Description = "Sliced beef, hummus, rice, and salad.", Price = 12.50M, ImageUrl = "shawarma.jpg", Category = MenuCategory.Meal },
                    new MenuItem { Name = "Teriyaki Tofu Bowl", Description = "Tofu with teriyaki glaze, edamame, and rice.", Price = 11.25M, ImageUrl = "tofu_bowl.jpg", Category = MenuCategory.Meal },
                    new MenuItem { Name = "Fish & Chips", Description = "Crispy battered fish with fries and tartar sauce.", Price = 12.75M, ImageUrl = "fish_chips.jpg", Category = MenuCategory.Meal },

                    new MenuItem { Name = "Fresh Lemonade", Description = "Classic, tangy, and refreshing.", Price = 2.99M, ImageUrl = "lemonade.jpg", Category = MenuCategory.Drink },
                    new MenuItem { Name = "Mango Smoothie", Description = "Thick and fruity mango blend.", Price = 3.99M, ImageUrl = "mango_smoothie.jpg", Category = MenuCategory.Drink },
                    new MenuItem { Name = "Cold Brew Coffee", Description = "Slow-steeped and smooth iced coffee.", Price = 3.49M, ImageUrl = "cold_brew.jpg", Category = MenuCategory.Drink },
                    new MenuItem { Name = "Chai Milk Tea", Description = "Sweet and spiced with black tea.", Price = 3.25M, ImageUrl = "chai.jpg", Category = MenuCategory.Drink },

                    new MenuItem { Name = "Chocolate Lava Cake", Description = "Warm cake with molten chocolate center.", Price = 4.99M, ImageUrl = "lava_cake.jpeg", Category = MenuCategory.Dessert },
                    new MenuItem { Name = "Vanilla Ice Cream", Description = "Classic scoop of real vanilla ice cream.", Price = 2.50M, ImageUrl = "vanilla_icecream.jpg", Category = MenuCategory.Dessert },
                    new MenuItem { Name = "Strawberry Cheesecake", Description = "Rich and creamy with strawberry topping.", Price = 5.25M, ImageUrl = "cheesecake.jpeg", Category = MenuCategory.Dessert },
                    new MenuItem { Name = "Churros with Chocolate", Description = "Cinnamon-dusted churros served with dip.", Price = 3.75M, ImageUrl = "churros.jpg", Category = MenuCategory.Dessert },
                };

                context.MenuItems.AddRange(items);
                context.SaveChanges();
            }
        }
    }
}
