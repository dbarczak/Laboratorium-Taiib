
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
    public enum Type
    {
        Admin, Casual
    }
    public class User 
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Login { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public Type Type { get; set; }

        public IEnumerable<Order>? Orders { get; set; }
        public IEnumerable<BasketPosition>? BasketPositions { get; set; }

        
    }
}
