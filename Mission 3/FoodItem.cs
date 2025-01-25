//Food Bank Inventory System
//This system allows a local food bank to manage its inventory by adding, deleting, and listing food items, ensuring better tracking and reduced waste.
//Made by - Samuel Richey

using System;

namespace FoodBankInventory
{
    // Class to represent a food item
    public class FoodItem
    {
        // Properties for food name, category, quantity, and expiration date
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Constructor to initialize a food item with provided values
        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            // Validation for input values
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Food name cannot be empty.");
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category cannot be empty.");
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");
            if (expirationDate < DateTime.Now)
                throw new ArgumentException("Expiration date cannot be in the past.");

            // Assign values to the properties
            Name = name;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }

        // Override ToString method to display a formatted string for a food item
        public override string ToString()
        {
            return $"{Name} | {Category} | {Quantity} units | Expires: {ExpirationDate.ToShortDateString()}";
        }
    }
}

