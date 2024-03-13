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
    [Table("ORDER")]
    public class Order : IEntityTypeConfiguration<Order>
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Column("UserID"), Required]
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID)), Required]
        public User User { get; set; }
        
        public IEnumerable<OrderPosition> OrderPositions { get; set; }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(p => p.User).WithMany(p=>p.Orders).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p=>p.OrderPositions).WithOne(p=>p.Order).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
