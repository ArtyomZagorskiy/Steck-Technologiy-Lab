using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Library;

namespace Lab2
{
    class Program
    {
        static void main(string[] args)
        {
            String[] A = {"Falluot 3", "Daxter 2", "System Shok 2", "Morrowind", "Pes 2013"};

            int[] B = { 2, -7, -10, 6, 7, 9, 3 };

            String[] C = { "Light Green", "Red", "Green", "Yellow", "Purple", "Dark Green",
                            "Light Red", "Dark Red", "Dark Yellow",  "Light Yellow"};

            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

            //Написати запит для знаходження елементів масиву А, що включають пробіл
            var elementsWithSpace = A.Where(x => x.Contains(" ")).ToArray();

            //Написати запит для знаходження позитивних елементів масиву В
            var positiveElementsFromB = B.Where(x => x > 0).ToArray();

            //Написати запит для знаходження всіх відтінків червоного кольору в масиві С
            var redElements = C.Where(x => x.Contains("Red")).ToArray();

            //Вивести результуючий набір списків myCars та yourCars, що містить усі елементи з повтореннями.
            var carsLists = myCars.Concat(yourCars).ToList();

            //4)	Створити перелік автомобілів класу Car. Вибрати зі списку автомобілі максимальна швидкість яких перевищує 200 км/год та вивести всю інформацію про них.
            List<Car> cars = new List<Car>
            {
                new Car { color = "Red", maxSpeed = 180, countOfPassengers = 4, manufacturer = "VW" },
                new Car { color = "Blue", maxSpeed = 220, countOfPassengers = 2, manufacturer = "BMW" },
                new Car { color = "Black", maxSpeed = 240, countOfPassengers = 5, manufacturer = "Mercedes" },
                new Car { color = "Red", maxSpeed = 190, countOfPassengers = 5, manufacturer = "Mazda" },
                new Car { color = "Blue", maxSpeed = 230, countOfPassengers = 4, manufacturer = "Lamborghini" },
                new Car { color = "Black", maxSpeed = 260, countOfPassengers = 2, manufacturer = "Porsche" }
            };

            var carsWithSpeed200 = cars.Where(x => x.maxSpeed > 200).ToArray();
            foreach(Car car in carsWithSpeed200)
            {
                Console.WriteLine(car.ToString());
            }

            //Створити перелік продуктів класу Product.Вибрати зі списку продукти, асортимент яких менше 5 одиниць та вивести всю інформацію про них.
            List<Product> products = new List<Product>
            {
                new Product { Name = "Product A", countOfProductInStock = 3, Description = "Good Product" },
                new Product { Name = "Product B", countOfProductInStock = 10, Description = "Bad Product" },
                new Product { Name = "Product C", countOfProductInStock = 2, Description = "Just product" }
            };

            var productsInStockLessThan5 = products.Where(x => x.countOfProductInStock < 5).ToArray();
            foreach (Product product in productsInStockLessThan5)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}

