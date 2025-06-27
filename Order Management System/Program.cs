using Order_Management_System.DAO;
using Order_Management_System.Entity;
using Order_Management_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System
{
    public class Program
    {
        static void Main()
        {
            OrderProcessor repo = new OrderProcessor();
            while (true)
            {
                Console.WriteLine("\n ==== Order Management System");
                Console.WriteLine("1.Create User");
                Console.WriteLine("2.Create Product");
                Console.WriteLine("3.cancel Order");
                Console.WriteLine("4.Get All Products");
                Console.WriteLine("5.Get Order By User");
                Console.WriteLine("6.Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Username: ");
                            string username = Console.ReadLine();
                            Console.Write("Enter Password: ");
                            string password = Console.ReadLine();
                            Console.Write("Enter Role (Admin/User): ");
                            string role = Console.ReadLine();
                            User user = new User { Username = username, Password = password, Role = role };
                            repo.CreateUser(user);
                            Console.WriteLine("User created.");
                            break;

                        case "2":
                            Console.Write("Enter Admin UserId: ");
                            int adminId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Product Type (Electronics/Clothing): ");
                            string type = Console.ReadLine();
                            Product product = null;
                            Console.Write("Enter Product Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Description: ");
                            string desc = Console.ReadLine();
                            Console.Write("Enter Price: ");
                            double price = double.Parse(Console.ReadLine());
                            Console.Write("Enter Quantity: ");
                            int qty = int.Parse(Console.ReadLine());

                            if (type.ToLower() == "electronics")
                            {
                                Console.Write("Enter Brand: ");
                                string brand = Console.ReadLine();
                                Console.Write("Enter Warranty Period (months): ");
                                int warranty = int.Parse(Console.ReadLine());

                                product = new Electronics
                                {
                                    ProductName = name,
                                    Description = desc,
                                    Price = price,
                                    QuantityInStock = qty,
                                    Type = "Electronics",
                                    Brand = brand,
                                    WarrantyPeriod = warranty
                                };
                            }
                            else if (type.ToLower() == "clothing")
                            {
                                Console.Write("Enter Size: ");
                                string size = Console.ReadLine();
                                Console.Write("Enter Color: ");
                                string color = Console.ReadLine();

                                product = new Clothing
                                {
                                    ProductName = name,
                                    Description = desc,
                                    Price = price,
                                    QuantityInStock = qty,
                                    Type = "Clothing",
                                    Size = size,
                                    Color = color
                                };
                            }

                            repo.CreateProduct(new User { UserId = adminId }, product);
                            Console.WriteLine("Product created.");
                            break;

                        case "3":
                            Console.Write("Enter UserId: ");
                            int uid = int.Parse(Console.ReadLine());
                            Console.Write("Enter OrderId: ");
                            int oid = int.Parse(Console.ReadLine());
                            repo.CancelOrder(uid, oid);
                            Console.WriteLine("Order cancelled.");
                            break;

                        case "4":
                            List<Product> allProducts = repo.GetAllProducts();
                            Console.WriteLine("Products:");
                            foreach (var p in allProducts)
                            {
                                Console.WriteLine($"Id: {p.ProductId}, Name: {p.ProductName}, Price: {p.Price}");
                            }
                            break;

                        case "5":
                            Console.Write("Enter UserId: ");
                            int userID = int.Parse(Console.ReadLine());

                            var orders = repo.GetOrderByUser(new User { UserId = userID });
                            Console.WriteLine($"Orders placed by UserId {userID}:");
                            foreach (var o in orders)
                            {
                                Console.WriteLine($"OrderId: {o.OrderId}, ProductId: {o.ProductId}, Date: {o.OrderDate}");
                            }
                            break;

                        case "7":
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (UserNotFoundException ex)
                {
                    Console.WriteLine($"[Error] {ex.Message}");
                }
                catch (OrderNotFoundException ex)
                {
                    Console.WriteLine($"[Error] {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Unexpected Error] {ex.Message}");
                }
            }
        }
    }

}
       
