using FriGo.Db.EntityConfigurations;
using FriGo.Db.Models.Ingredients;

namespace FriGo.Db
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FrigoContext : DbContext
    {       
        public FrigoContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FrigoContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new IngredientConfiguration());
            modelBuilder.Configurations.Add(new IngredientQuantityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientQuantity> IngredientQuantities { get; set; }
    }
}