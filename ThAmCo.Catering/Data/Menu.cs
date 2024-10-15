using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static System.Collections.Specialized.BitVector32;

namespace ThAmCo.Catering.Data
{
    public class Menu
    {
        public int MenuId { get; set; }
        [MaxLength(50)]
        public required string MenuName { get; set; }

        // List of Food Items (many side of one-to-many)
        public List<MenuFoodItem>? MenuFoodItems { get; set; }

        // List of Bookings (many side of one-to-many)
        public List<FoodBooking >? Bookings { get; set; } 
    }
}
