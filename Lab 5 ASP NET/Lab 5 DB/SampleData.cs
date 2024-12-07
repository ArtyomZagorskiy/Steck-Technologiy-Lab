using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab_5_ASP_NET.Models;

namespace Lab_5_DB
{
    public static class SampleData
    {
        public static void Initialize(DbContext context)
        {
            if (!context.Set<Product>().Any())
            {
                context.Set<Product>().AddRange(
                    new Product("Молоко", 25, "л", 42),
                    new Product("Яйця", 12, "шт", 155),
                    new Product("Цукор", 10, "г", 387),
                    new Product("Борошно", 18, "г", 364),
                    new Product("Сіль", 2, "г", 0),
                    new Product("Олія соняшникова", 50, "мл", 884),
                    new Product("Сир", 120, "г", 402),
                    new Product("Картопля", 10, "г", 77),
                    new Product("Помідори", 15, "г", 18),
                    new Product("Огірки", 12, "г", 16),
                    new Product("Куряче філе", 90, "г", 165),
                    new Product("Рис", 25, "г", 130),
                    new Product("Гречка", 22, "г", 132),
                    new Product("Морква", 9, "г", 41),
                    new Product("Цибуля", 8, "г", 40),
                    new Product("Перець болгарський", 20, "г", 27),
                    new Product("Яблука", 15, "г", 52),
                    new Product("Банани", 30, "г", 89),
                    new Product("Мед", 60, "г", 304),
                    new Product("Шоколад", 80, "г", 546)
                );

                context.SaveChanges();
            }

            if (!context.Set<Recipe>().Any())
            {
                context.Set<Recipe>().AddRange(
                    new Recipe
                    {
                        Name = "Млинці",
                        Description = "Смачні домашні млинці.",
                        Type = "Сніданок",
                        PreparationTime = TimeSpan.FromMinutes(30),
                        Components = new List<RecipeComponent>
                        {
                            new RecipeComponent
                            {
                                Product = context.Set<Product>().FirstOrDefault(p => p.Name == "Молоко"),
                                Quantity = 0.5
                            },
                            new RecipeComponent
                            {
                                Product = context.Set<Product>().FirstOrDefault(p => p.Name == "Яйця"),
                                Quantity = 2
                            },
                            new RecipeComponent
                            {
                                Product = context.Set<Product>().FirstOrDefault(p => p.Name == "Цукор"),
                                Quantity = 50
                            }
                        }
                    },
                    new Recipe
                    {
                        Name = "Омлет",
                        Description = "Простий і швидкий омлет.",
                        Type = "Сніданок",
                        PreparationTime = TimeSpan.FromMinutes(15),
                        Components = new List<RecipeComponent>
                        {
                            new RecipeComponent
                            {
                                Product = context.Set<Product>().FirstOrDefault(p => p.Name == "Яйця"),
                                Quantity = 3
                            },
                            new RecipeComponent
                            {
                                Product = context.Set<Product>().FirstOrDefault(p => p.Name == "Молоко"),
                                Quantity = 0.2
                            }
                        }
                    }
                );

                context.SaveChanges();
            }
        }

    }
}
