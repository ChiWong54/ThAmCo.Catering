using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class MenuFoodItem
    {
        [Required]
        public int MenuId { get; set; }
        public required int FoodItemId { get; set; }

        // Navigation property to Trainer (one side of one-to-many)
        public Menu? Menu { get; set; }

        // Navigation property to Category (one side of one-to-many)
        public FoodItem? Category { get; set; } 
    }
}
