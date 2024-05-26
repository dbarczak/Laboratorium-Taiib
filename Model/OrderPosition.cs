using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderPosition
    {
        [Key]
        public int ID { get; set; }
        
        public Order Order { get; set; }
        [ForeignKey(nameof(OrderID))]
        public int OrderID { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int ProductID { get; set; }
        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }


    }
}
