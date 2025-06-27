namespace Order_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                {
                    OrderId = c.Int(nullable: false, identity: true),
                    OrderDate = c.DateTime(nullable: false),
                    UserId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.OrderId);

            // Insert sample order records (ensure UserId and ProductId exist)
            Sql("INSERT INTO dbo.Orders (OrderDate, UserId, ProductId) VALUES ('2025-06-26', 1, 1)");
            Sql("INSERT INTO dbo.Orders (OrderDate, UserId, ProductId) VALUES ('2025-06-26', 2, 2)");
            Sql("INSERT INTO dbo.Orders (OrderDate, UserId, ProductId) VALUES ('2025-06-27', 3, 3)");
            Sql("INSERT INTO dbo.Orders (OrderDate, UserId, ProductId) VALUES ('2025-06-27', 2, 4)");
        }

        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}