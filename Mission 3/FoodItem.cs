using System;

namespace FoodBankInventory
{
    public class FoodItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }

        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Food name cannot be empty.");
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category cannot be empty.");
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");
            if (expirationDate < DateTime.Now)
                throw new ArgumentException("Expiration date cannot be in the past.");

            Name = name;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            return $"{Name} | {Category} | {Quantity} units | Expires: {ExpirationDate.ToShortDateString()}";
        }
    }
}
