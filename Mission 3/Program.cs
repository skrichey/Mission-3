//Food Bank Inventory System
//This system allows a local food bank to manage its inventory by adding, deleting, and listing food items, ensuring better tracking and reduced waste.
//Made by - Samuel Richey

using System;
using System.Collections.Generic;

namespace FoodBankInventory
{
    class Program
    {
        // A list to store all food items in the inventory
        static List<FoodItem> foodItems = new List<FoodItem>();

        // Main method to display the menu and handle user input
        static void Main(string[] args)
        {
            while (true) // Infinite loop to keep the program running until user exits
            {
                // Display menu options
                Console.WriteLine("\n--- Food Bank Inventory System ---");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine(); // Get user choice

                // Handle user choice
                switch (choice)
                {
                    case "1":
                        AddFoodItem(); // Add a food item
                        break;
                    case "2":
                        DeleteFoodItem(); // Delete a food item
                        break;
                    case "3":
                        PrintFoodItems(); // Print all food items
                        break;
                    case "4":
                        Console.WriteLine("Exiting program...");
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        // Method to add a new food item to the inventory
        static void AddFoodItem()
        {
            try
            {
                // Prompt user for food details
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

                // Add the food item to the list
                foodItems.Add(new FoodItem(name, category, quantity, expirationDate));
                Console.WriteLine("Food item added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); // Display error messages for invalid inputs
            }
        }

        // Method to delete a food item from the inventory
        static void DeleteFoodItem()
        {
            try
            {
                // Prompt user for the name of the food item to delete
                Console.Write("Enter the name of the food item to delete: ");
                string nameToDelete = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nameToDelete))
                    throw new ArgumentException("Food name cannot be empty.");

                // Find the item in the list
                FoodItem item = foodItems.Find(f => f.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

                if (item != null)
                {
                    foodItems.Remove(item); // Remove the item from the list
                    Console.WriteLine("Food item deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Food item not found."); // If the item doesn't exist
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); // Display error messages
            }
        }

        // Method to print all food items in the inventory
        static void PrintFoodItems()
        {
            if (foodItems.Count == 0) // Check if the list is empty
            {
                Console.WriteLine("No food items in inventory.");
                return;
            }

            // Display all food items
            Console.WriteLine("\n--- Current Food Items ---");
            foreach (var item in foodItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}

