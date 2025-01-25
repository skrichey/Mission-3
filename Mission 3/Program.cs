using System;
using System.Collections.Generic;

namespace FoodBankInventory
{
    class Program
    {
        static List<FoodItem> foodItems = new List<FoodItem>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Food Bank Inventory System ---");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddFoodItem();
                        break;
                    case "2":
                        DeleteFoodItem();
                        break;
                    case "3":
                        PrintFoodItems();
                        break;
                    case "4":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static void AddFoodItem()
        {
            try
            {
                Console.Write("Enter food name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Food name cannot be empty.");

                Console.Write("Enter category (e.g., Canned Goods, Dairy, Produce): ");
                string category = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(category))
                    throw new ArgumentException("Category cannot be empty.");

                Console.Write("Enter quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
                    throw new ArgumentException("Quantity must be a non-negative number.");

                Console.Write("Enter expiration date (MM/DD/YYYY): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime expirationDate) || expirationDate < DateTime.Now)
                    throw new ArgumentException("Expiration date must be a valid future date.");

                foodItems.Add(new FoodItem(name, category, quantity, expirationDate));
                Console.WriteLine("Food item added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeleteFoodItem()
        {
            try
            {
                Console.Write("Enter the name of the food item to delete: ");
                string nameToDelete = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nameToDelete))
                    throw new ArgumentException("Food name cannot be empty.");

                FoodItem item = foodItems.Find(f => f.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

                if (item != null)
                {
                    foodItems.Remove(item);
                    Console.WriteLine("Food item deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Food item not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void PrintFoodItems()
        {
            if (foodItems.Count == 0)
            {
                Console.WriteLine("No food items in inventory.");
                return;
            }

            Console.WriteLine("\n--- Current Food Items ---");
            foreach (var item in foodItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}
