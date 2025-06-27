using Order_Management_System.Entity;
using Order_Management_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.DAO
{
    public class OrderProcessor : IOrderManagementRepository
    {
        private readonly OrderContext context = new OrderContext();
        public void CreateUser(User user)
        {
            var existing = context.Users.FirstOrDefault(u => u.Username == user.Username);
            if (existing == null)
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void CreateProduct(User user, Product product)
        {
            var admin = context.Users.FirstOrDefault(u => u.UserId == user.UserId && u.Role == "Admin");
            if (admin == null)
                throw new UserNotFoundException("Admin user not found.");

            context.Products.Add(product);
            context.SaveChanges();
        }

        public void CreateOrder(User user, List<Product> products)
        {
            var existingUser = context.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existingUser == null)
            {
                context.Users.Add(user);
                context.SaveChanges();
                existingUser = user;
            }

            foreach (var prod in products)
            {
                var product = context.Products.Find(prod.ProductId);
                if (product == null) continue;

                Order order = new Order
                {
                    UserId = existingUser.UserId,
                    OrderDate = DateTime.Now,
                    ProductId = product.ProductId
                };

                context.Orders.Add(order);
            }

            context.SaveChanges();
        }

        public void CancelOrder(int userId, int orderId)
        {
            var user = context.Users.Find(userId);
            if (user == null)
                throw new UserNotFoundException("User not found.");

            var order = context.Orders.FirstOrDefault(o => o.OrderId == orderId && o.UserId == userId);
            if (order == null)
                throw new OrderNotFoundException("Order not found.");

            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public List<Order> GetOrderByUser(User user)
        {
            var existing = context.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existing == null)
                throw new UserNotFoundException("User not found.");

            return context.Orders.Where(o => o.UserId == user.UserId).ToList();
        }
    }
}
