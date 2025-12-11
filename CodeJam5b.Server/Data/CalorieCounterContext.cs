using Microsoft.EntityFrameworkCore;
using CodeJam5b.Models;

namespace CodeJam5b.Server.Data
{
    public class CalorieCounterContext : DbContext
    {
        public CalorieCounterContext(DbContextOptions<CalorieCounterContext> options)
            : base(options)
        {
        }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Progress> Progress { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Meal>().HasData(

                new Meal
                {
                    MealId = "1",
                    MealName = "Chicken Salad",
                    Calories = 350,
                    Carbs = 10,
                    Fat = 15,
                    Protein = 40
                },
                new Meal
                {
                    MealId = "2",
                    MealName = "Grilled Salmon",
                    Calories = 450,
                    Carbs = 5,
                    Fat = 25,
                    Protein = 50
                },
                new Meal
                {
                    MealId = "3",
                    MealName = "Veggie Stir Fry",
                    Calories = 300,
                    Carbs = 50,
                    Fat = 10,
                    Protein = 15
                }

             );

            modelBuilder.Entity<Progress>().HasData(
                new Progress 
                { 
                    ProgressId = "1",
                    CurrentWeight = 180,
                    TargetWeight = 160,
                    TargetCals = 2000,
                    TargetCarbs = 250,
                    TargetFat = 80,
                    TargetProtein = 160
                }    
            );

        }
    
    }
    
}
