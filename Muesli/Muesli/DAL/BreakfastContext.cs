using Muesli.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Muesli.DAL
{
    public class BreakfastContext : DbContext
    {

        public BreakfastContext() : base("BreakfastContext")
        {
        }
 
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Ingredient_Category> Ingredient_Categories { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<BreakfastContext>();
        }
    }
}



