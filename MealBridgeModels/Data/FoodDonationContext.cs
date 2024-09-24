using MealBridgeModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealBridgeModels.Data
{
    public class FoodDonationContext:DbContext
    {
        public FoodDonationContext(DbContextOptions<FoodDonationContext>options):base(options)
        {
                
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Donation> Donations { get; set; }

       


    }
}
