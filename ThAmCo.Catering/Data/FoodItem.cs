using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class FoodItem
    {
        [Key]
        public required int FoodItemId { get; set; }
        
        [MaxLength(50)]
        public required string  Description{ get; set; }
        public required double UnitPrice { get; set; }

        // List of food items (many side of one-to-many)
        public List<MenuFoodItem>? MenuFoodItems { get; set; } 
    }
}
