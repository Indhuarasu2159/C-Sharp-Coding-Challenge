
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Entity
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("name=MyConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Electronics> Electronics { get; set; }
        public DbSet<Clothing> Clothings { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
