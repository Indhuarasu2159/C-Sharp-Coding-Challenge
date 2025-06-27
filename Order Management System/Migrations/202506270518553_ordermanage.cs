namespace Order_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ordermanage : DbMigration
    {
        public override void Up()
        {
            // Create Products table
            CreateTable(
                "dbo.Products",
                c => new
                {
                    ProductId = c.Int(nullable: false, identity: true),
                    ProductName = c.String(),
                    Description = c.String(),
                    Price = c.Double(nullable: false),
                    QuantityInStock = c.Int(nullable: false),
                    Type = c.String(),
                    Size = c.String(),
                    Color = c.String(),
                    Brand = c.String(),
                    WarrantyPeriod = c.Int(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.ProductId);

            // Create Users table
            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    Username = c.String(),
                    Password = c.String(),
                    Role = c.String(),
                })
                .PrimaryKey(t => t.UserId);

            // Insert Users
            Sql("INSERT INTO dbo.Users (Username, Password, Role) VALUES ('priya', 'adminpass', 'Admin')");
            Sql("INSERT INTO dbo.Users (Username, Password, Role) VALUES ('aravindh', 'userpass', 'User')");
            Sql("INSERT INTO dbo.Users (Username, Password, Role) VALUES ('kalpana', 'password123', 'User')");

            // Insert Electronics
            Sql("INSERT INTO dbo.Products (ProductName, Description, Price, QuantityInStock, Type, Brand, WarrantyPeriod, Discriminator) " +
                "VALUES ('Smartphone', 'Android phone', 15000, 25, 'Electronics', 'Samsung', 12, 'Electronics')");

            Sql("INSERT INTO dbo.Products (ProductName, Description, Price, QuantityInStock, Type, Brand, WarrantyPeriod, Discriminator) " +
                "VALUES ('Bluetooth Speaker', 'Portable speaker', 3000, 50, 'Electronics', 'Boat', 6, 'Electronics')");

            // Insert Clothing
            Sql("INSERT INTO dbo.Products (ProductName, Description, Price, QuantityInStock, Type, Size, Color, Discriminator) " +
                "VALUES ('Jeans', 'Denim pants', 1200, 100, 'Clothing', 'L', 'Blue', 'Clothing')");

            Sql("INSERT INTO dbo.Products (ProductName, Description, Price, QuantityInStock, Type, Size, Color, Discriminator) " +
                "VALUES ('Hoodie', 'Warm cotton hoodie', 899, 75, 'Clothing', 'M', 'Black', 'Clothing')");
        }

        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Products");
        }
    }

}
