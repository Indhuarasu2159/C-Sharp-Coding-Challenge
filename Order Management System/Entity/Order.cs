using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public int ProductId { get; set; }

    }

}


