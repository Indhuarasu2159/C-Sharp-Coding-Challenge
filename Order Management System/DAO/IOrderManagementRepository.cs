using Order_Management_System.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.DAO
{
    public interface IOrderManagementRepository
    {
        void CreateUser(User user);
        void CreateProduct(User user, Product product);
        void CreateOrder(User user, List<Product> products);
        void CancelOrder(int userId, int orderId);
        List<Product> GetAllProducts();
        List<Order> GetOrderByUser(User user);
    }
}
