namespace Order_Management_System.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Order_Management_System.Entity.OrderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Order_Management_System.Entity.OrderContext context)
        {
            // Insert Users
            context.Database.ExecuteSqlCommand(@"
            INSERT INTO dbo.Users (Username, Password, Role) VALUES 
            ('priya', 'adminpass', 'Admin'),
            ('aravindh', 'userpass', 'User'),
            ('kalpana', 'password123', 'User')");

            // Insert Electronics
            context.Database.ExecuteSqlCommand(@"
            INSERT INTO dbo.Products (ProductName, Description, Price, QuantityInStock, Type, Brand, WarrantyPeriod, Discriminator) VALUES 
            ('Smartphone', 'Android phone', 15000, 25, 'Electronics', 'Samsung', 12, 'Electronics'),
            ('Bluetooth Speaker', 'Portable speaker', 3000, 50, 'Electronics', 'Boat', 6, 'Electronics')");

            // Insert Clothing
            context.Database.ExecuteSqlCommand(@"
            INSERT INTO dbo.Products (ProductName, Description, Price, QuantityInStock, Type, Size, Color, Discriminator) VALUES 
            ('Jeans', 'Denim pants', 1200, 100, 'Clothing', 'L', 'Blue', 'Clothing'),
            ('Hoodie', 'Warm cotton hoodie', 899, 75, 'Clothing', 'M', 'Black', 'Clothing')");
        }
    }
}
