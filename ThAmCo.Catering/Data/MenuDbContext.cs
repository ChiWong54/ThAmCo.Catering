using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace ThAmCo.Catering.Data
{
    public class MenuDbContext : DbContext
    {
        // Notes
        // - DbSet defines the database table.
        // - the class name is defined as part of the data model
        // - the instance/object name is normally plural
        // - by default, the instance name will become the table name
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItem { get; set; }
        public DbSet<FoodBooking> Bookings { get; set; }
        private string DbPath { get; set; } = string.Empty;
        // Constructor to set-up the database path & name
        public MenuDbContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "ThAmCo.Catering.db");
        }
        // OnConfiguring to specify that the SQLite database engine will be used
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Composite (Compound) Key
            builder.Entity<MenuFoodItem>()
            .HasKey(ts => new { ts.MenuId, ts.FoodItemId });
            // EF Core can work out most relationships from the navigation properties
            // One "Category" to many "TrainerCategories" needs to be defined because it does
            // NOT have a “conventional” primary column name (i.e. CategoryId) and is based
            // on a Composite key
            builder.Entity<FoodItem>()
            .HasMany(c => c.MenuFoodItems)
            .WithOne(tr => tr.Category)
            .HasForeignKey(tr => tr.FoodItemId)
            .OnDelete(DeleteBehavior.Restrict);
            // The OnDelete prevents categories from being deleted if there are
            // corresponding entities within the TrainerCategories
            // Manually define the Trainer to TrainerCategories relationship to
            // enforce the delete rule.
            builder.Entity<Menu>()
            .HasMany(c => c.MenuFoodItems)
            .WithOne(tr => tr.Menu)
            .OnDelete(DeleteBehavior.Restrict);
            // Seed/Test data to be added here
            // Insert Seed/Test Data
            builder.Entity<FoodItem>().HasData(
            new FoodItem { FoodItemId = 1, Description = "", UnitPrice = 9.99 },
            new FoodItem { FoodItemId = 2, Description = "", UnitPrice = 9.99 },
            new FoodItem { FoodItemId = 3, Description = "", UnitPrice = 9.99 },
            new FoodItem { FoodItemId = 4, Description = "", UnitPrice = 9.99 },
            new FoodItem { FoodItemId = 5, Description = "", UnitPrice = 9.99 }
            );
            builder.Entity<Menu>().HasData(
            new Menu { MenuId = 1, MenuName = "" },
            new Menu { MenuId = 2, MenuName = "" },
            new Menu { MenuId = 3, MenuName = "" },
            new Menu { MenuId = 4, MenuName = "" }
            );
            builder.Entity<MenuFoodItem>().HasData(
            new MenuFoodItem { MenuId = 1, FoodItemId = 1 },
            new MenuFoodItem { MenuId = 1, FoodItemId = 2 },
            new MenuFoodItem { MenuId = 2, FoodItemId = 4 },
            new MenuFoodItem { MenuId = 2, FoodItemId = 2 },
            new MenuFoodItem { MenuId = 2, FoodItemId = 3 },
            new MenuFoodItem { MenuId = 3, FoodItemId = 1 },
            new MenuFoodItem { MenuId = 3, FoodItemId = 3 }
            );
            builder.Entity<FoodBooking>().HasData(
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 },
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 20, MenuId = 1 }
            );
        }
    }
}
