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
    [Table("ORDERPOSITION")]
    public class OrderPosition : IEntityTypeConfiguration<OrderPosition>
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        [Column("OrderID")]
        public int OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }
        [Column("ProductID")]
        public int ProductID { get; set; }
        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public void Configure(EntityTypeBuilder<OrderPosition> builder)
        {
            builder.HasOne(p => p.Order).WithMany(p => p.OrderPositions).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
