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
    public class BasketPosition 
    {
        [Key]
        public int ID { get; set; }
        
        public Product Product { get; set; }
        [ForeignKey(nameof(ProductID))]
        public int ProductID { get; set; }
        
        
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }

        public int Amount { get; set; }
        
    }
}
