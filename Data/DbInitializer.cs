using CheersMandu.Models;
using Microsoft.EntityFrameworkCore;

namespace CheersMandu.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
                context.SaveChanges();
            }

            if (!context.Drinks.Any())
            {
                context.AddRange(
                    new Drink
                    {
                        Name = "Beer",
                        Price = 7.95M,
                        ShortDescription = "The most widely consumed alcohol",
                        LongDescription = "Beer is the world's oldest and most widely consumed alcoholic drink.",
                        Category = Categories["Alcoholic"],
                        ImageUrl = "https://images.unsplash.com/photo-1608270586620-248524c67de9?w=800",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "https://images.unsplash.com/photo-1608270586620-248524c67de9?w=400"
                    },
                    new Drink
                    {
                        Name = "Rum & Coke",
                        Price = 12.95M,
                        ShortDescription = "Cocktail made of cola, lime and rum.",
                        LongDescription = "The world's second most popular drink.",
                        Category = Categories["Alcoholic"],
                        ImageUrl = "https://images.unsplash.com/photo-1514362545857-3bc16c4c7d1b?w=800",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "https://images.unsplash.com/photo-1514362545857-3bc16c4c7d1b?w=400"
                    },
                    new Drink
                    {
                        Name = "Tequila",
                        Price = 12.95M,
                        ShortDescription = "Beverage made from the blue agave plant.",
                        LongDescription = "Tequila is a regionally specific name for a distilled beverage.",
                        Category = Categories["Alcoholic"],
                        ImageUrl = "https://images.unsplash.com/photo-1514361892635-6b07e31e75f9?w=800",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "https://images.unsplash.com/photo-1514361892635-6b07e31e75f9?w=400"
                    },
                    new Drink
                    {
                        Name = "Wine",
                        Price = 16.75M,
                        ShortDescription = "A very elegant alcoholic drink",
                        LongDescription = "Wine is an alcoholic drink typically made from fermented grapes.",
                        Category = Categories["Alcoholic"],
                        ImageUrl = "https://images.unsplash.com/photo-1510812431401-41d2bd2722f3?w=800",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "https://images.unsplash.com/photo-1510812431401-41d2bd2722f3?w=400"
                    },
                    new Drink
                    {
                        Name = "Margarita",
                        Price = 17.95M,
                        ShortDescription = "A cocktail with sec, tequila and lime",
                        LongDescription = "A classic cocktail.",
                        Category = Categories["Alcoholic"],
                        ImageUrl = "https://images.unsplash.com/photo-1551024709-8f23befc6f87?w=800",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "https://images.unsplash.com/photo-1551024709-8f23befc6f87?w=400"
                    },
                    new Drink
                    {
                        Name = "Tea",
                        Price = 12.95M,
                        ShortDescription = "Made by leaves of the tea plant in hot water.",
                        LongDescription = "Tea is an aromatic beverage.",
                        Category = Categories["Non-alcoholic"],
                        ImageUrl = "https://images.unsplash.com/photo-1571934811356-5cc061b6821f?w=800",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "https://images.unsplash.com/photo-1571934811356-5cc061b6821f?w=400"
                    },
                    new Drink
                    {
                        Name = "Coffee",
                        Price = 12.95M,
                        ShortDescription = "A beverage prepared from coffee beans",
                        LongDescription = "Coffee is a brewed drink prepared from roasted coffee beans.",
                        Category = Categories["Non-alcoholic"],
                        ImageUrl = "https://images.unsplash.com/photo-1495474472287-4d71bcdd2085?w=800",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "https://images.unsplash.com/photo-1495474472287-4d71bcdd2085?w=400"
                    },
                    new Drink
                    {
                        Name = "Juice",
                        Price = 12.95M,
                        ShortDescription = "Naturally contained in fruit or vegetable tissue.",
                        LongDescription = "Juice is a drink made from the extraction of fruit or vegetables.",
                        Category = Categories["Non-alcoholic"],
                        ImageUrl = "https://images.unsplash.com/photo-1621506289937-a8e4df240d0b?w=800",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "https://images.unsplash.com/photo-1621506289937-a8e4df240d0b?w=400"
                    },
                    new Drink
                    {
                        Name = "Water",
                        Price = 5.95M,
                        ShortDescription = "It makes up more than half of your body weight",
                        LongDescription = "Water is essential for life.",
                        Category = Categories["Non-alcoholic"],
                        ImageUrl = "https://images.unsplash.com/photo-1548839140-29a749e1cf4d?w=800",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "https://images.unsplash.com/photo-1548839140-29a749e1cf4d?w=400"
                    }
                );

                context.SaveChanges();
            }
        }

        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Alcoholic", Description = "All alcoholic drinks" },
                        new Category { CategoryName = "Non-alcoholic", Description = "All non-alcoholic drinks" }
                    };

                    categories = new Dictionary<string, Category>();
                    foreach (var category in list)
                    {
                        categories.Add(category.CategoryName, category);
                    }
                }
                return categories;
            }
        }
    }
}