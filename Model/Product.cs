using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<BasketPosition>? BasketPositions { get; set; }
        public IEnumerable<OrderPosition>? OrderPositions { get; set; }
    }
}
